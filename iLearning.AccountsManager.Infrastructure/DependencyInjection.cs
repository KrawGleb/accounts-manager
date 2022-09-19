using iLearning.AccountsManager.Infrastructure.Persistence;
using iLearning.AccountsManager.Infrastructure.Persistence.Repositories;
using iLearning.AccountsManager.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iLearning.AccountsManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options
                .UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped<IAccountsRepository, AccountsRepository>();

        return services;
    }
}
