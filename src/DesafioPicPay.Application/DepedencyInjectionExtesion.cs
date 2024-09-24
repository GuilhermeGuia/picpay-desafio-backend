using DesafioPicPay.Application.Services.User;
using DesafioPicPay.Infrastructure.Crypto;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioPicPay.Application;

public static class DepedencyInjectionExtesion
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUserAppService, UserAppService>();
    }
}
