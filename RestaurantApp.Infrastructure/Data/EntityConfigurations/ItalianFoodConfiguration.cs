using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Infrastructure.Data.EntityConfigurations
{
    public class ItalianFoodConfiguration : IEntityTypeConfiguration<ItalianFood>
    {
        public void Configure(EntityTypeBuilder<ItalianFood> builder)
        {
        }
    }
}
