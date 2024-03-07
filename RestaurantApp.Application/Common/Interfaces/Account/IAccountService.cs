using RestaurantApp.Application.Common.DTOs.Account;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.Users;
using RestaurantApp.Domain.Users.ValueObjects;

namespace RestaurantApp.Application.Common.Interfaces.Account
{
    public interface IAccountService
    {
        Task RegisterAsync(UserCreateDto userDto);
        Task<AccessToken> LoginAsync(UserLoginDto userDto);
        Task<User> GetUserAsync(Specification<User> filter);
        Task<T> GetUserAsync<T>(Specification<User> filter);
        Task<bool> IsUserInRoleAsync(Guid userId, RoleName roleName);
        Task ConfirmUserEmailAsync(Guid userId, string token);
    }
}
