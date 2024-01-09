using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Domain.Users;
using RestaurantApp.Domain.Users.ValueObjects;
using RestaurantApp.Infrastructure.Common.Extensions;
using RestaurantApp.Infrastructure.Common.Interfaces.Authentication;
using RestaurantApp.Infrastructure.Data;
using System.Linq.Expressions;

namespace RestaurantApp.Infrastructure.Authentication
{
    public class UserManager : IUserManager
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<UserManager> _logger;

        public UserManager(AppDbContext dbContext, ILogger<UserManager> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task CreateAsync(User user)
        {
            _dbContext.Users.Add(user);

            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
            {
                _logger.LogError($"Can't save this user");
                throw new ServerErrorException("An error occurred while trying to save");
            }
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> condition, bool tracking = false)
        {
            var user = await _dbContext.Users
                .Tracking(tracking)
                .FirstOrDefaultAsync(condition);

            return user;
        }

        public async Task<bool> UserExistedAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(x => x.Email.NormalizedEmail == email.ToUpper());
        }

        public async Task<bool> IsUserInRoleAsync(Guid userId, RoleName role)
        {
            return await _dbContext.Users.AnyAsync(x => x.Id == userId && x.Role.Name.Value == role.Value);
        }

        public async Task<bool> ConfirmEmail(User user, string token)
        {
            user.ConfirmEmail(token);

            var result = await _dbContext.SaveChangesAsync();

            if(result == 0)
            {
                _logger.LogError("Error occured while trying to save changes to user {0}", user.Id);
                return false;
            }

            return true;
        }
    }
}
