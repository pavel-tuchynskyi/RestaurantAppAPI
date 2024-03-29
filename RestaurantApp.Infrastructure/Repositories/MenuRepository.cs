﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Infrastructure.Common.Extensions;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Repositories
{
    public class MenuRepository<T> : RepositoryBase<T>, IMenuRepository<T>
        where T : MenuItem
    {
        public MenuRepository(AppDbContext dbContext, IMapper mapper, ILogger<T> logger) : base(dbContext, mapper, logger)
        {
        }

        public override async Task<T> GetByIdAsync(Guid id, bool tracking = false)
        {
            var item = await _entities
                .Tracking(tracking)
                .IncludeOnCondition(nameof(Set.Ingridients),
                    () => !typeof(T).IsSubclassOf(typeof(DrinkMenuItem)))
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item is null)
            {
                _logger.LogInformation($"Can't find menu item with if {id}");
                throw new NotFoundException("Can't find this menu item");
            }

            return item;
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
                .IncludeOnCondition(nameof(Set.Ingridients),
                    () => !typeof(T).IsSubclassOf(typeof(DrinkMenuItem)))
                .Filter(filter)
                .Sort(orderBy, ascending)
                .ToPagedListAsync(pageNumber, pageSize);

            return items;
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
                .IncludeOnCondition(nameof(Set.Ingridients),
                    () => !typeof(T).IsSubclassOf(typeof(DrinkMenuItem)))
                .Filter(filter)
                .Sort(orderBy, ascending)
                .ProjectTo<T, R>(_mapper)
                .ToPagedListAsync(pageNumber, pageSize);

            return items;
        }
    }
}
