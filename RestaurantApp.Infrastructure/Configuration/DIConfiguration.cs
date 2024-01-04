using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            services.AddScoped<IUserManager, UserManager>();
            services.AddSingleton<PasswordHasher>();
            services.AddSingleton<JwtTokenGenerator>();
            services.AddScoped<IRoleManager, RoleManager>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped(typeof(IMenuRepository<>), typeof(FoodRepository<>));
            services.AddScoped(typeof(IMenuRepository<>), typeof(DrinkRepository<>));
            services.AddScoped(typeof(IIngridientsRepository<>), typeof(IngridientsRepository<>));
            services.AddScoped<IOrderRepository, OrdersRepository>();

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
