using DesafioPicPay.Domain.Crypto;
using DesafioPicPay.Domain.Repositories;
using DesafioPicPay.Infrastructure.Crypto;
using DesafioPicPay.Infrastructure.DataAccess;
using DesafioPicPay.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioPicPay.Infrastructure;

public static class DepedencyInjectionExtesion
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddCrypto(services);
        AddRepositories(services);
    }
    public static void AddCrypto(IServiceCollection services)
    {
        services.AddScoped<IPasswordEncryptor, PasswordEncryptor>();
    }
    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<DesafioPicPayDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

}
