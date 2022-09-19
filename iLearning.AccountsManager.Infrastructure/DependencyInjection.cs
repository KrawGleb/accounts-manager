using iLearning.AccountsManager.Infrastructure.Auth;
using iLearning.AccountsManager.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iLearning.AccountsManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthenticationDbContext>(options => 
            options
                .UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

        services.AddIdentity<Account, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDbContext>();

        return services;
    }
}
