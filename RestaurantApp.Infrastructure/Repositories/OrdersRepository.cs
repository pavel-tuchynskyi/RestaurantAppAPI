using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.Interfaces.Orders;
using RestaurantApp.Domain.Orders;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Repositories
{
    public class OrdersRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrdersRepository(AppDbContext dbContext, IMapper mapper, ILogger<Order> logger) : base(dbContext, mapper, logger)
        {
        }
    }
}
