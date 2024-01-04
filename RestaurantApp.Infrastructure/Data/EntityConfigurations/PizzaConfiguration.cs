using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasMany(p => p.Ingridients)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "PizzaIngridients",
                    j => j.HasOne<ItalianFoodIngridient>()
                        .WithMany()
                        .HasForeignKey("IngridientId"),
                    j => j.HasOne<Pizza>()
                        .WithMany()
                        .HasForeignKey("PizzaId"));

            builder.Navigation(p => p.Ingridients)
                .AutoInclude()
                .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
