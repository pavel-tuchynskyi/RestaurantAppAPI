using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class RollsConfiguration : IEntityTypeConfiguration<Rolls>
    {
        public void Configure(EntityTypeBuilder<Rolls> builder)
        {
            builder.HasMany(p => p.Ingridients)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RollsIngridients",
                    j => j.HasOne<JapaneesFoodIngridient>()
                        .WithMany()
                        .HasForeignKey("IngridientId"),
                    j => j.HasOne<Rolls>()
                        .WithMany()
                        .HasForeignKey("RollsId"));

            builder.Navigation(p => p.Ingridients)
                .AutoInclude()
                .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
