using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class IngridientConfiguration : IEntityTypeConfiguration<Ingridient>
    {
        public void Configure(EntityTypeBuilder<Ingridient> builder)
        {
            builder.ToTable("Ingridients");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("IngridientId");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasConversion(p => p.Value, value => ItemName.Create(value));

            builder.OwnsOne(p => p.Image, p =>
            {
                p.Property(pp => pp.ImageBlob)
                    .HasColumnName("ImageBlob");

                p.Property(pp => pp.ImageType)
                    .HasColumnName("ImageType")
                    .HasConversion<string>();
            });
        }
    }
}
