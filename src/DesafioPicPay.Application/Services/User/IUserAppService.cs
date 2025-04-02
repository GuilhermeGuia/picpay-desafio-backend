using DesafioPicPay.Application.Services.User.Dto;

namespace DesafioPicPay.Application.Services.User;

public interface IUserAppService
{
    Task<UserOutput> Get(long Id);
    Task<CreateUserOutput> Create(CreateUserInput input);
}
