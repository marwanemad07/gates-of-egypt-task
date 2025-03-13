﻿using System.Reflection;

namespace ECommerceApp.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }

}
