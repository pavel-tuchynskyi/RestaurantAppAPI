using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.DTOs.Orders
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public decimal Price { get; set; }
    }
}
