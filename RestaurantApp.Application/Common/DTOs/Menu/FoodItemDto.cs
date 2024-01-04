using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.DTOs.Menu
{
    public class FoodItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public decimal Price { get; set; }
        public List<IngridientDto> Ingridients { get; set; }
    }
}
