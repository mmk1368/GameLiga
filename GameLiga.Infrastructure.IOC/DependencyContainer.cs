using System;
using System.Collections.Generic;
using System.Text;
using GameLiga.Core.Config.Permission;
using GameLiga.Core.Interfaces;
using GameLiga.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace GameLiga.Infrastructure.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            //services.AddScoped<IDataBase, DataBase>();
            services.AddScoped<IAccount, Account>();
            services.AddScoped<INews, News>();

            return services;
        }
    }
}

