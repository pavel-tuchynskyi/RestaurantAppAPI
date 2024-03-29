﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.Application.Common.Interfaces;
using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Interfaces.Orders;
using RestaurantApp.Infrastructure.Authentication;
using RestaurantApp.Infrastructure.Common.Interfaces.Authentication;
using RestaurantApp.Infrastructure.Data;
using RestaurantApp.Infrastructure.Repositories;
using RestaurantApp.Infrastructure.Services;
using System.Text;

namespace RestaurantApp.Infrastructure.Configuration
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            services.ConfigureAuthentication(configuration);

            services.RegisterOption(configuration, typeof(JwtSettings));
            services.RegisterOption(configuration, typeof(PasswordHasherSettings));
            services.RegisterOption(configuration, typeof(SmtpConfiguration));
            services.RegisterOption(configuration, typeof(EmailTemplates));
            services.RegisterOption(configuration, typeof(ClientUrl));

            services.AddSingleton<IClientUrlSettings>(sp =>
                sp.GetRequiredService<IOptions<ClientUrl>>().Value);

            services.AddScoped<IUserManager, UserManager>();
            services.AddSingleton<PasswordHasher>();
            services.AddSingleton<TokenGenerator>();
            services.AddScoped<IRoleManager, RoleManager>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped(typeof(IMenuRepository<>), typeof(MenuRepository<>));
            services.AddScoped(typeof(IIngridientsRepository<>), typeof(IngridientsRepository<>));
            services.AddScoped<IOrderRepository, OrdersRepository>();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ITemplateService, EmailTemplateService>();

            return services;
        }

        private static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), jwtSettings);

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });
        }
    }
}
