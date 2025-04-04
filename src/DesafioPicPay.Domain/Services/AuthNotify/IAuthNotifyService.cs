using DesafioPicPay.Domain.Services.AuthNotify.Dto;

namespace DesafioPicPay.Domain.Services.AuthNotify;

public interface IAuthNotifyService
{
    Task<AuthorizationResponseOutput> GetAuthorization();
    Task SendNotification();
}
