using DesafioPicPay.Application.Services.User.Dto;
using DesafioPicPay.Exception;
using DesafioPicPay.Exception.ExceptionBase;

namespace DesafioPicPay.Application.Validators.User;

public class CreateUserValidation : IValidator<CreateUserInput>
{
    public List<string> Errors { get; set; } = [];
    public void Execute(CreateUserInput input)
    {
        Validate(input);

        if(Errors.Count > 0)
        {
            throw new ErrorOnValidationException(Errors);
        }
    }
    public void Validate(CreateUserInput input)
    {
        if (string.IsNullOrWhiteSpace(input.NomeCompleto))
            Errors.Add(ResourceMessageExceptions.NAME_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Email))
            Errors.Add(ResourceMessageExceptions.EMAIL_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Cpf))
            Errors.Add(ResourceMessageExceptions.CPF_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Password))
            Errors.Add(ResourceMessageExceptions.PASSWORD_EMPTY);
    }
}
