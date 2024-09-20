using DesafioPicPay.Application.Services.User.Dto;
using DesafioPicPay.Application.Validators.User;

namespace DesafioPicPay.Application.Services.User;

public class UserAppService : IUserAppService
{
    public CreateUserOutput Create(CreateUserInput input)
    {
        // criar um usuario no banco de dados
        // validar
        var validate = new CreateUserValidation();
        validate.Validade(input);

        

        // fazer mapping de info
        // salvar no banco de dados
        // retornar nome pro usuario

        return new CreateUserOutput() { NomeCompleto = input.NomeCompleto };
    }

    #region
    public void Delete(CreateUserInput input)
    {
        throw new NotImplementedException();
    }

    public void Get(CreateUserInput input)
    {
        throw new NotImplementedException();
    }

    public void GetAll(CreateUserInput input)
    {
        throw new NotImplementedException();
    }

    public void Update(CreateUserInput input)
    {
        throw new NotImplementedException();
    }
    #endregion
}
