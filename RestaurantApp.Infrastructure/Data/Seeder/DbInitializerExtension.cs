using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Infrastructure.Authentication;

namespace RestaurantApp.Infrastructure.Data.Seeder
{
    public static class DbInitializerExtension
    {
        public async static Task<IApplicationBuilder> SeedDbData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                var hasher = services.GetRequiredService<PasswordHasher>();
                await new DbInitializer().Initialize(context, hasher);
            }

            return app;
        }
    }
}
