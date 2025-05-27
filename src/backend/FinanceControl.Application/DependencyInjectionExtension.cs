using FinanceControl.Application.Services.AutoMapper;
using FinanceControl.Application.Services.Cryptography;
using FinanceControl.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceControl.Application;

public static class DependencyInjectionExtension
{
    public static void AddAplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCase(services);
        AddPasswordEncrypter(services);
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
    
    private static void AddPasswordEncrypter(IServiceCollection services)
    {
        services.AddScoped(options => new PasswordEncrypter());
    }
}