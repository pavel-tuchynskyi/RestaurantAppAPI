using RestaurantApp.Domain.Users.Entities;
using RestaurantApp.Domain.Users.ValueObjects;

namespace RestaurantApp.Infrastructure.Common.Interfaces.Authentication
{
    public interface IRoleManager
    {
        Task<Role> GetByNameAsync(RoleName name);
    }
}