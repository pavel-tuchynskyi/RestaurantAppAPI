using RestaurantApp.Application.Common.Models;

namespace RestaurantApp.Web.Contracts.Orders
{
    public record GetAllOrdersRequest(
        Guid UserId,
        OrderBy OrderBy,
        Paging Paging);
}
