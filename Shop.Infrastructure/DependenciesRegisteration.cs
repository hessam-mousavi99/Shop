﻿using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Infrastructure.Services;
using Shop.Persistence.Repositories.Accounts;
using Shop.Persistence.Repositories.ProductEntities;
using Shop.Persistence.Repositories.Wallets;

namespace Shop.Infrastructure
{
    public static class DependenciesRegisteration
    {
        public static void ConfigureDependenciesRegisteration(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<ISmsService, SmsService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductGalleryRepository, ProductGalleryRepository>();
            services.AddScoped<IProductFeatureRepository, ProductFeatureRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            #endregion
        }
    }
}
