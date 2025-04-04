using DesafioPicPay.Application.Services.Transfer.Dto;
using DesafioPicPay.Application.Validators;
using DesafioPicPay.Domain.Repositories;
using DesafioPicPay.Domain.Services.AuthNotify;
using DesafioPicPay.Exception;
using DesafioPicPay.Exception.ExceptionBase;
using System.Reflection;

namespace DesafioPicPay.Application.Services.Transfer;

public class TransferAppService : ITransferAppService
{
    private readonly IRepository<Domain.Entities.Transfer> _transferRepository;
    private readonly IRepository<Domain.Entities.User> _userRepository;
    private readonly IAuthNotifyService _authNotifyService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly TransferValidator _validator;
    public TransferAppService(IUnitOfWork unitOfWork, IRepository<Domain.Entities.Transfer> transferRepository, IRepository<Domain.Entities.User> userRepository, IAuthNotifyService authNotifyService, TransferValidator validator)
    {
        _unitOfWork = unitOfWork;
        _transferRepository = transferRepository;
        _userRepository = userRepository;
        _validator = validator;
        _authNotifyService = authNotifyService;
    }

    public async Task<Guid> Transfer(TransferInput input)
    {
        var authorization = await _authNotifyService.GetAuthorization();
        if (!authorization.Data.Authorization)
            throw new UnaAuthorizedException();

        var senderAccount = await _userRepository.Find(x => x.Id == input.SenderId);
        var receiverAccount = await _userRepository.Find(x => x.Id == input.ReceiverId);

        if (senderAccount is null || receiverAccount is null)
            throw new ErrorOnValidationException(ResourceMessageExceptions.ACCOUNT_NOT_FOUND);

        if (senderAccount.UserType == Domain.Entities.Enums.EUserType.Lojista)
            throw new ShopkeeperException();

        _validator.SendTransferValidation(senderAccount, input);

        senderAccount.Debit(input.Value);
        receiverAccount.Credit(input.Value);

        var transfer = new Domain.Entities.Transfer(receiverAccount.Id, senderAccount.Id, input.Value);

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            _userRepository.Update(senderAccount);
            _userRepository.Update(receiverAccount);

            await _transferRepository.Add(transfer);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();
        }
        catch (System.Exception ex)
        {
            await _unitOfWork.RollbackAsync();

            throw new ErrorOnTransferException();
        }

        await _authNotifyService.SendNotification();
        return transfer.Id;
    }
}
