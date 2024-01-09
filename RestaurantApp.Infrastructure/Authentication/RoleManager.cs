using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Domain.Users.Entities;
using RestaurantApp.Domain.Users.ValueObjects;
using RestaurantApp.Infrastructure.Common.Interfaces.Authentication;
using RestaurantApp.Infrastructure.Data;

namespace RestaurantApp.Infrastructure.Authentication
{
    public class RoleManager : IRoleManager
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<RoleManager> _logger;

        public RoleManager(AppDbContext dbContext, ILogger<RoleManager> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Role> GetByNameAsync(RoleName name)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name.Value == name.Value);

            if (role is null)
            {
                _logger.LogError($"Can't find role: {name.Value}");
                throw new NotFoundException("Can't find this role");
            }

            return role;
        }
    }
}
