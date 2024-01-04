using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.MenuItems;

namespace RestaurantApp.Application.Common.Interfaces.MenuItems
{
    public interface IMenuRepository<T>
        where T : MenuItem
    {
        Task<T> GetByIdAsync(Guid id, bool tracking = false);
        Task<R> GetByIdAsync<R>(Guid id, bool tracking = false);
        Task<PagedList<R>> GetAllAsync<R>(Specification<T> filter, string? orderBy = null, bool ascending = true, int pageNumber = -1, int pageSize = -1, bool tracking = false);
        Task<PagedList<T>> GetAllAsync(Specification<T> filter, string? orderBy = null, bool ascending = true, int pageNumber = -1, int pageSize = -1, bool tracking = false);
        Task CreateAsync(T item);
        Task Delete(Guid id);
        Task Update(T item);
    }
}
