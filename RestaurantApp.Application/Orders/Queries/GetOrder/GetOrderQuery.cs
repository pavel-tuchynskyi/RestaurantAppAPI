using MediatR;
using RestaurantApp.Application.Common.DTOs.Orders;

namespace RestaurantApp.Application.Orders.Queries.GetOrder
{
    public record GetOrderQuery (Guid Id) : IRequest<OrderDto>;
}
