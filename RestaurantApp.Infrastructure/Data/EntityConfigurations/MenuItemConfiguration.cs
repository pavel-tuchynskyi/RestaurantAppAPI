using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("MenuItemId");

            builder.Property(p => p.Name).HasConversion(p => p.Value, value => ItemName.Create(value));

            builder.OwnsOne(p => p.Image, p =>
            {
                p.Property(pp => pp.ImageBlob)
                    .HasColumnName("ImageBlob");

                p.Property(pp => pp.ImageType)
                    .HasColumnName("ImageType")
                    .HasConversion<string>();
            });

            builder.Property(p => p.Price).HasConversion(p => p.Value, value => Price.Create(value));
        }
    }
}
