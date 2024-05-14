using Microsoft.Extensions.DependencyInjection;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public static class Extentions
    {
        public static IServiceCollection AddRepositoriesInjections(this IServiceCollection services)
        {
            //services.AddScoped<IRoleRepository, RoleRepository>();
            //services.AddScoped<IPermissionRepository, PermissionRepository>();
            //services.AddScoped<IClaimRepository, ClaimRepository>();
            
            services.AddScoped<IChildRepository, ChildRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
