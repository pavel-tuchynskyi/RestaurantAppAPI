using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class SetsConfiguration : IEntityTypeConfiguration<Set>
    {
        public void Configure(EntityTypeBuilder<Set> builder)
        {
            builder.HasMany(p => p.Ingridients)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "SetComponents",
                    j => j.HasOne<JapaneesFood>()
                        .WithMany()
                        .HasForeignKey("JapaneesFoodId"),
                    j => j.HasOne<Set>()
                        .WithMany()
                        .HasForeignKey("SetId"));

            builder.Navigation(p => p.Ingridients)
                .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
