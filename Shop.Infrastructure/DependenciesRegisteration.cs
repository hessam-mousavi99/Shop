using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Infrastructure.Services;
using Shop.Persistence.Repositories.Accounts;

namespace Shop.Infrastructure
{
    public static class DependenciesRegisteration
    {
        public static void ConfigureDependenciesRegisteration(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
