using DesafioPicPay.Application.Services.Transfer;
using DesafioPicPay.Application.Services.User;
using DesafioPicPay.Application.Services.User.Dto;
using DesafioPicPay.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioPicPay.Application;

public static class DepedencyInjectionExtesion
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddMappers(services);
        AddServices(services);
        AddValidators(services);
    }
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUserAppService, UserAppService>();
        services.AddScoped<ITransferAppService, TransferAppService>();
    }
    public static void AddMappers(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile<UserMapProfile>();
        }).CreateMapper());
    }
    public static void AddValidators(IServiceCollection services)
    {
        services.AddScoped<UserValidator>();
        services.AddScoped<TransferValidator>();
    }
}
