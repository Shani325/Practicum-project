using Microsoft.Extensions.DependencyInjection;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyProject.Repositories;

namespace MyProject.Services
{
    public static class Extentions
    {
        public static IServiceCollection AddServicesInjections (this IServiceCollection services)
        {
            services.AddRepositoriesInjections();

            //services.AddScoped<IRoleService, RoleService>();
            //services.AddScoped<IPermissionService, PermissionService>();
            //services.AddScoped<IClaimService, ClaimService>();

            services.AddScoped<IChildService, ChildService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(Mapping));
            return services;
        }
    }
}
