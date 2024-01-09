using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;

namespace RestaurantApp.Application.Common.Interfaces.MenuItems
{
    public interface IIngridientsRepository<T>
    {
        Task CreateAsync(T ingridient);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync(Specification<T> filter);
        Task<PagedList<R>> GetAllAsync<R>(Specification<T> filter);
        Task Delete(Guid id);
        Task Update(T item);
    }
}
