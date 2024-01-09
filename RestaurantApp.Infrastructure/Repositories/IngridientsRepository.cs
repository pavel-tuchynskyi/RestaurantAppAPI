using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Repositories
{
    public class IngridientsRepository<T> : RepositoryBase<T>, IIngridientsRepository<T>
        where T : Ingridient
    {
        public IngridientsRepository(AppDbContext dbContext, IMapper mapper, ILogger<T> logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<List<T>> GetAllAsync(Specification<T> filter)
        {
            var ingridients = await base.GetAllAsync(filter, tracking: true);

            return ingridients.Items.ToList();
        }

        public async Task<PagedList<R>> GetAllAsync<R>(Specification<T> filter)
        {
            var ingridients = await base.GetAllAsync<R>(filter, tracking: true);

            return ingridients;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var ingridient = await base.GetByIdAsync(id, true);

            return ingridient;
        }
    }
}
