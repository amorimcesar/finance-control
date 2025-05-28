using FinanceControl.Domain.Repositories;
using FinanceControl.Domain.Repositories.User;
using FinanceControl.Infrastructure.DataAccess;
using FinanceControl.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceControl.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var serverVersion = new MySqlServerVersion(new Version(8, 4, 3));

        services.AddDbContext<FinanceControlDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseMySql(connectionString, serverVersion);
        });
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IWorkUnity, WorkUnity>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}