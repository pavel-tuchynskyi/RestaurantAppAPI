using RestaurantApp.Domain.Users;
using RestaurantApp.Domain.Users.ValueObjects;
using System.Linq.Expressions;

namespace RestaurantApp.Infrastructure.Common.Interfaces.Authentication
{
    public interface IUserManager
    {
        Task CreateAsync(User user);
        Task<User> FindAsync(Expression<Func<User, bool>> condition, bool tracking = false);
        Task<bool> UserExistedAsync(string email);
        Task<bool> IsUserInRoleAsync(Guid userId, RoleName role);
        Task<bool> ConfirmEmail(User user, string token);
    }
}