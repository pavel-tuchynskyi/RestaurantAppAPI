using MediatR;

namespace RestaurantApp.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand (
        string City,
        string Address,
        Guid CreatedBy,
        List<Guid> Items
        ) 
        : IRequest<Unit>;
}
