using DesafioPicPay.Infrastructure.Crypto;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioPicPay.Infrastructure;

public static class DepedencyInjectionExtesion
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddCrypto(services);
    }
    public static void AddCrypto(IServiceCollection services)
    {
        services.AddScoped<IPasswordEncryptor, PasswordEncryptor>();
    }
}
