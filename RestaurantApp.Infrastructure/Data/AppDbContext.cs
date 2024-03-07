using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Common.Interfaces;
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
        private readonly IPublisher _publisher;

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
        public DbSet<NonAlcohol> NonAlcoholDrink { get; set; }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<Wine> Wine { get; set; }

        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<JapaneesFoodIngridient> JapaneesIngridients { get; set; }
        public DbSet<ItalianFoodIngridient> ItalianIngridient { get; set; }

        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Ignore<List<IDomainEvent>>();

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<Entity>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();

            var domainEvents = entities.SelectMany(x => x.DomainEvents).ToList();

            entities.ForEach(x => x.ClearDomainEvents());

            var saveResult = await base.SaveChangesAsync(cancellationToken);

            if(saveResult == 0)
            {
                return saveResult;
            }

            foreach(var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }

            return saveResult;
        }
    }
}