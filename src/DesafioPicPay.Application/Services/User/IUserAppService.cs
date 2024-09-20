using DesafioPicPay.Application.Services.User.Dto;

namespace DesafioPicPay.Application.Services.User;

public interface IUserAppService
{
    public void Get(CreateUserInput input);
    public void GetAll(CreateUserInput input);
    public CreateUserOutput Create(CreateUserInput input);
    public void Update(CreateUserInput input);
    public void Delete(CreateUserInput input);
}
