using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class SusiConfiguration : IEntityTypeConfiguration<Susi>
    {
        public void Configure(EntityTypeBuilder<Susi> builder)
        {
            builder.HasMany(p => p.Ingridients)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "SusiIngridients",
                    j => j.HasOne<JapaneesFoodIngridient>()
                        .WithMany()
                        .HasForeignKey("IngridientId"),
                    j => j.HasOne<Susi>()
                        .WithMany()
                        .HasForeignKey("SusiId"));

            builder.Navigation(p => p.Ingridients)
                .AutoInclude()
                .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
