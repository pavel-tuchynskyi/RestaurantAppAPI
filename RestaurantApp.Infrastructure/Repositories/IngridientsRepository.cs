using AutoMapper;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Repositories
{
    public class IngridientsRepository<T> : RepositoryBase<T>, IIngridientsRepository<T>
        where T : Ingridient
    {
        public IngridientsRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<T>> GetAllAsync(Specification<T> filter)
        {
            var ingridients = await base.GetAllAsync(filter, tracking: true);

            return ingridients.Items.ToList();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var ingridient = await base.GetByIdAsync(id, true);

            return ingridient;
        }
    }
}
