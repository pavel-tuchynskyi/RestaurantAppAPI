using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.DTOs.Menu
{
    public class IngridientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
    }
}
