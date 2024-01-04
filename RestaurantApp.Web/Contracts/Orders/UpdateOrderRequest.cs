using RestaurantApp.Domain.Orders;

namespace RestaurantApp.Web.Contracts.Orders
{
    public record UpdateOrderRequest (
        Guid OrderId,
        string City,
        string Address,
        OrderStatus Status
        );
}
