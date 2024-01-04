using Microsoft.EntityFrameworkCore;
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

        public UserManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User user)
        {
            _dbContext.Users.Add(user);

            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
            {
                throw new ServerErrorException("Can't save this user");
            }
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> condition, bool tracking = false)
        {
            var user = await _dbContext.Users
                .Tracking(tracking)
                .FirstOrDefaultAsync(condition);

            if (user is null)
            {
                throw new NotFoundException("Can't find this user");
            }

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
    }
}
