using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class JapaneesFoodConfiguration : IEntityTypeConfiguration<JapaneesFood>
    {
        public void Configure(EntityTypeBuilder<JapaneesFood> builder)
        {
        }
    }
}
