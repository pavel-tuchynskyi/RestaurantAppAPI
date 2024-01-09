using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Repositories
{
    public class DrinkRepository<T> : RepositoryBase<T>, IMenuRepository<T>
        where T : MenuItem
    {
        public DrinkRepository(AppDbContext dbContext, IMapper mapper, ILogger<T> logger) : base(dbContext, mapper, logger)
        {
        }
    }
}
