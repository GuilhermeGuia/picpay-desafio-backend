using DesafioPicPay.Application.Services.User.Dto;
using DesafioPicPay.Exception;
namespace DesafioPicPay.Application.Validators.User;

public class CreateUserValidation
{
    public void Validade(CreateUserInput input)
    {
        if (string.IsNullOrWhiteSpace(input.NomeCompleto))
            throw new System.Exception(ResourceMessageExceptions.NAME_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Email))
            throw new System.Exception(ResourceMessageExceptions.EMAIL_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Cpf))
            throw new System.Exception(ResourceMessageExceptions.CPF_EMPTY);

        if (string.IsNullOrWhiteSpace(input.Password))
            throw new System.Exception(ResourceMessageExceptions.PASSWORD_EMPTY);

    }
}
