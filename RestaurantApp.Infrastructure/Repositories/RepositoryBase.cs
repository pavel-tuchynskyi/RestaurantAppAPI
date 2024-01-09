using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.Common;
using RestaurantApp.Infrastructure.Common.Extensions;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Repositories
{
    public class RepositoryBase<T>
        where T : Entity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;
        protected readonly DbSet<T> _entities;

        public RepositoryBase(AppDbContext dbContext, IMapper mapper, ILogger<T> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _entities = dbContext.Set<T>();
        }

        public virtual async Task CreateAsync(T item)
        {
            _entities.Add(item);

            await SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id, bool tracking = false)
        {
            var item = await _entities
                    .Tracking(tracking)
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (item is null)
            {
                _logger.LogError($"Can't find item with id {id}");
                throw new NotFoundException("Can't find this item");
            }

            return item;
        }

        public virtual async Task<R> GetByIdAsync<R>(Guid id, bool tracking = false)
        {
            var item = await GetByIdAsync(id, tracking);

            return _mapper.Map<R>(item);
        }

        public virtual async Task<PagedList<T>> GetAllAsync(
            Specification<T> filter,
            string? orderBy = null,
            bool ascending = true,
            int pageNumber = -1,
            int pageSize = -1,
            bool tracking = false)
        {
            var items = await _entities
                .Tracking(tracking)
                .Filter(filter)
                .Sort(orderBy, ascending)
                .ToPagedListAsync(pageNumber, pageSize);

            return items;
        }

        public virtual async Task<PagedList<R>> GetAllAsync<R>(
            Specification<T> filter,
            string? orderBy = null,
            bool ascending = true,
            int pageNumber = -1,
            int pageSize = -1,
            bool tracking = false)
        {
            var items = await _entities
                .Tracking(tracking)
                .Filter(filter)
                .Sort(orderBy, ascending)
                .ProjectTo<T, R>(_mapper)
                .ToPagedListAsync(pageNumber, pageSize);

            return items;
        }

        public virtual async Task Delete(Guid id)
        {
            var itemToRemove = await GetByIdAsync(id);

            _entities.Remove(itemToRemove);
            await SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            _entities.Attach(item);

            await SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
            {
                _logger.LogError($"Can't save this entity, or modified rows didn't change.");
                throw new ServerErrorException("An error occurred while trying to save");
            }
        }
    }
}
