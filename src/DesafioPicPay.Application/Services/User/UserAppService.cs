using AutoMapper;
using DesafioPicPay.Application.Services.User.Dto;
using DesafioPicPay.Application.Validators;
using DesafioPicPay.Domain.Crypto;
using DesafioPicPay.Domain.Repositories;
using DesafioPicPay.Exception.ExceptionBase;
using DesafioPicPay.Exception;

namespace DesafioPicPay.Application.Services.User;

public class UserAppService : IUserAppService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.Entities.User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordEncryptor _passwordEncryptor;
    private readonly UserValidator _validator;

    public UserAppService(
        IMapper mapper, IRepository<Domain.Entities.User> userRepository, IUnitOfWork unitOfWork,
        IPasswordEncryptor passwordEncryptor, UserValidator validator)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordEncryptor = passwordEncryptor;
        _validator = validator;
    }

    public async Task<UserOutput> Get(long Id)
    {
        var user = await _userRepository.GetById(Id);

        if (user == null)
            throw new ErrorOnValidationException(ResourceMessageExceptions.USER_NOT_FOUND);

        var mapped = _mapper.Map<UserOutput>(user);

        return mapped;
    }

    public async Task<CreateUserOutput> Create(CreateUserInput input)
    {
        _validator.CreateUserValidation(input);

        if (await _userRepository.Find(x => x.Email == input.Email) != null || await _userRepository.Find(x => x.Cpf == input.Cpf) != null)
            throw new AccountAlreadyExistsException();

        var user = _mapper.Map<Domain.Entities.User>(input);

        user.Password = _passwordEncryptor.Encrypt(input.Password);

        await _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync();

        return new CreateUserOutput() { FullName = input.FullName };
    }

}
