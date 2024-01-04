using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class DrinkMenuItemConfiguration : IEntityTypeConfiguration<DrinkMenuItem>
    {
        public void Configure(EntityTypeBuilder<DrinkMenuItem> builder)
        {
            builder.Property(p => p.Description).HasConversion(p => p.Value, value => Description.Create(value));
        }
    }
}
