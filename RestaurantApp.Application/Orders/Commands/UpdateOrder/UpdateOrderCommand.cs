using MediatR;
using RestaurantApp.Domain.Orders;

namespace RestaurantApp.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(
        Guid OrderId, 
        string City,
        string Address,
        OrderStatus Status) 
        : IRequest<Unit>;
}
