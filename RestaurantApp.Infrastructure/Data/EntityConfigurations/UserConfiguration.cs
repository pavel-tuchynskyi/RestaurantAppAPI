using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserId");

            builder.OwnsOne(p => p.Name, p =>
            {
                p.Property(pp => pp.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(30);

                p.Property(pp => pp.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(30);
            });

            builder.OwnsOne(p => p.Email, p =>
            {
                p.Property(pp => pp.Email)
                .HasColumnName("Email")
                .HasMaxLength(50);

                p.Property(pp => pp.NormalizedEmail)
                .HasColumnName("NormalizedEmail")
                .HasMaxLength(50);
            });

            builder.OwnsOne(p => p.PhoneNumber, p =>
            {
                p.Property(pp => pp.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(13);
            });

            builder.OwnsOne(p => p.Password, p =>
            {
                p.Property(pp => pp.PasswordHash)
                .HasColumnName("PasswordHash");

                p.Property(pp => pp.PasswordSalt)
                .HasColumnName("PasswordSalt");
            });

            builder.Property("RoleId").HasColumnName("RoleId");
            builder.HasOne(p => p.Role).WithMany().HasForeignKey("RoleId");
            builder.Navigation(p => p.Role).AutoInclude();
        }
    }
}
