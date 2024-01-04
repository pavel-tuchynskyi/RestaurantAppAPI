using Microsoft.EntityFrameworkCore;
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

        public RoleManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> GetByNameAsync(RoleName name)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name.Value == name.Value);

            if (role is null)
            {
                throw new NotFoundException("Can't find this role");
            }

            return role;
        }
    }
}
