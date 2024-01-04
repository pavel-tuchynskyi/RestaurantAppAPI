using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Infrastructure.Common.Extensions;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Repositories
{
    public class FoodRepository<T> : RepositoryBase<T>, IMenuRepository<T>
        where T : MenuItem
    {
        public FoodRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<T> GetByIdAsync(Guid id, bool tracking = false)
        {
            var item = await _entities
                    .Include(nameof(Set.Ingridients))
                    .Tracking(tracking)
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (item is null)
            {
                throw new NotFoundException("Can't find this menu item");
            }

            return item;
        }

        public override async Task<PagedList<R>> GetAllAsync<R>(
            Specification<T> filter,
            string? orderBy = null,
            bool ascending = true,
            int pageNumber = -1,
            int pageSize = -1,
            bool tracking = false)
        {
            var items = await _entities
                .Tracking(tracking)
                .Include(nameof(Set.Ingridients))
                .Filter(filter)
                .Sort(orderBy, ascending)
                .ProjectTo<T, R>(_mapper)
                .ToPagedListAsync(pageNumber, pageSize);

            return items;
        }

        public override async Task<PagedList<T>> GetAllAsync(
            Specification<T> filter,
            string? orderBy = null,
            bool ascending = true,
            int pageNumber = -1,
            int pageSize = -1,
            bool tracking = false)
        {
            var items = await _entities
                .Tracking(tracking)
                .Include(nameof(Set.Ingridients))
                .Filter(filter)
                .Sort(orderBy, ascending)
                .ToPagedListAsync(pageNumber, pageSize);

            return items;
        }
    }
}
