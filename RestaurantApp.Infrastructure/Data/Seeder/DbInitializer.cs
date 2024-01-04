using RestaurantApp.Domain.Users;
using RestaurantApp.Domain.Users.Entities;
using RestaurantApp.Domain.Users.ValueObjects;
using RestaurantApp.Infrastructure.Authentication;

namespace RestaurantApp.Infrastructure.Data.Seeder
{
    public class DbInitializer
    {
        public async Task Initialize(AppDbContext dbContext, PasswordHasher passwordHasher)
        {
            dbContext.Database.EnsureCreated();

            Console.WriteLine("Seed data?(y/n): ");
            var result = Console.ReadLine();

            if (result == "n")
            {
                return;
            }

            var userRole = new Role(RoleName.User);
            var adminRole = new Role(RoleName.Admin);

            var userHash = passwordHasher.HashPasword("123abc123", out var userSalt);

            var user = new User(
                Name.Create("User", "User"),
                UserEmail.Create("user@mail.com"),
                Phone.Create("+380000000000"),
                Password.Create(userHash, userSalt)
            );

            user.AddToRole(userRole);

            var adminHash = passwordHasher.HashPasword("123abc123", out var adminSalt);

            var admin = new User(
                Name.Create("Admin", "Admin"),
                UserEmail.Create("admin@mail.com"),
                Phone.Create("+380000000000"),
                Password.Create(adminHash, adminSalt)
            );

            admin.AddToRole(adminRole);

            Console.WriteLine("Insert operation started...");

            dbContext.AddRange(user, admin);
            var saveResult = await dbContext.SaveChangesAsync();

            if(saveResult == 0)
            {
                return;
            }

            Console.WriteLine("Insert operation completed");
        }
    }
}
