using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Italian;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Domain.Orders;
using RestaurantApp.Domain.Users;
using RestaurantApp.Domain.Users.Entities;

namespace RestaurantApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Role> Roles { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<ItalianFood> ItalianFood { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<JapaneesFood> JapaneesFoods { get; set; }
        public DbSet<Susi> Susis { get; set; }
        public DbSet<Rolls> Rolls { get; set; }
        public DbSet<Set> Sets { get; set; }

        public DbSet<DrinkMenuItem> DrinkMenuItems { get; set; }
        public DbSet<NonAlcoholDrink> NonAlcoholDrink { get; set; }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<Wine> Wine { get; set; }

        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<JapaneesFoodIngridient> JapaneesIngridients { get; set; }
        public DbSet<ItalianFoodIngridient> ItalianIngridient { get; set; }

        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}