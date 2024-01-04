using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Web.Middlewares;
using RestaurantApp.Web.Services;

namespace RestaurantApp.Web.Configuration
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<IUserContextService, UserContextService>();

            services.AddHttpContextAccessor();

            services.ConfigureCors();

            services.AddTransient<ErrorHandlingMiddleware>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        private static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AppCors", pol =>
                {
                    pol.AllowAnyOrigin();
                    pol.AllowAnyHeader();
                    pol.AllowAnyMethod();
                });
            });
        }
    }
}
