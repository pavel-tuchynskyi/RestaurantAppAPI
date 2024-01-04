using MediatR;
using RestaurantApp.Application.Common.DTOs.Orders;
using RestaurantApp.Application.Common.Models;

namespace RestaurantApp.Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery (
        Guid UserId,
        OrderBy OrderBy,
        Paging Paging
        ) 
        : IRequest<PagedList<OrderDto>>;
}
