using RestaurantApp.Application.Common.DTOs.Orders;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.Orders;

namespace RestaurantApp.Application.Common.Interfaces.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id, bool tracking = false);
        Task<PagedList<R>> GetAllAsync<R>(Specification<Order> filter, string? orderBy = null, bool ascending = true, int pageNumber = -1, int pageSize = -1, bool tracking = false);
        Task CreateAsync(Order item);
        Task Update(Order item);
    }
}
