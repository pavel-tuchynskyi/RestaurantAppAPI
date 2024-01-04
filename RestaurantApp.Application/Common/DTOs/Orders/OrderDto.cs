using RestaurantApp.Domain.Orders;

namespace RestaurantApp.Application.Common.DTOs.Orders
{
    public class OrderDto
    {
        public string City { get; set; }
        public string Address { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
    }
}
