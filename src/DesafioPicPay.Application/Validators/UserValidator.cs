using DesafioPicPay.Application.Services.User.Dto;
using DesafioPicPay.Application.Validators.Base;
using DesafioPicPay.Exception;
using DesafioPicPay.Exception.ExceptionBase;

namespace DesafioPicPay.Application.Validators;

public class UserValidator : Validator
{
    public void CreateUserValidation(CreateUserInput input)
    {
        if (string.IsNullOrWhiteSpace(input.FullName))
            AddErros(ResourceMessageExceptions.NAME_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Email))
            AddErros(ResourceMessageExceptions.EMAIL_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Cpf))
            AddErros(ResourceMessageExceptions.CPF_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Password))
            AddErros(ResourceMessageExceptions.PASSWORD_EMPTY);

        if (input.Password.Count() < 6)
            AddErros(ResourceMessageExceptions.PASSWORD_INVALID);

        ThrowIfInvalid<ErrorOnValidationException>();
    }
}
