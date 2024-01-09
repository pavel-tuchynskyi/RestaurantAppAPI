using MediatR;

namespace RestaurantApp.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand (
        string City,
        string Address,
        List<Guid> Items
        ) 
        : IRequest<Unit>;
}
