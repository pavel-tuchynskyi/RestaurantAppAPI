using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.ValueObjects;
using RestaurantApp.Domain.Orders;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("OrderId");

            builder.OwnsOne(p => p.Address, p =>
            {
                p.Property(pp => pp.City)
                    .HasColumnName("City");

                p.Property(pp => pp.Address)
                    .HasColumnName("Address");
            });

            builder.Property(p => p.Status).HasConversion<string>();

            builder.HasOne(p => p.CreatedBy).WithMany();
            builder.Navigation(p => p.CreatedBy).AutoInclude();

            builder.HasMany(p => p.Items)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "OrderItems",
                    j => j.HasOne<MenuItem>()
                        .WithMany()
                        .HasForeignKey("ItemId"),
                    j => j.HasOne<Order>()
                        .WithMany()
                        .HasForeignKey("OrderId"));

            builder.Navigation(p => p.Items)
                .AutoInclude()
                .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.Price).HasConversion(p => p.Value, value => Price.Create(value));
        }
    }
}
