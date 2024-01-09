using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Common.DTOs.Account;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.Users;
using RestaurantApp.Domain.Users.Events;
using RestaurantApp.Domain.Users.ValueObjects;
using RestaurantApp.Infrastructure.Authentication;
using RestaurantApp.Infrastructure.Common.Interfaces.Authentication;

namespace RestaurantApp.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserManager _userManager;
        private readonly PasswordHasher _passwordHasher;
        private readonly TokenGenerator _tokenGenerator;
        private readonly IRoleManager _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IUserManager userManager, 
            PasswordHasher passwordHasher, 
            TokenGenerator tokenGenerator,
            IRoleManager roleManager,
            IMapper mapper,
            ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task RegisterAsync(UserCreateDto userDto)
        {
            if (await _userManager.UserExistedAsync(userDto.Email))
            {
                _logger.LogError($"User with email {userDto.Email} already exist");
                throw new BadRequestException("User already exist");
            }

            var hash = _passwordHasher.HashPasword(userDto.Password, out var salt);

            var userRole = await _roleManager.GetByNameAsync(RoleName.User);

            var emailConfirmationToken = _tokenGenerator.GenerateEmailConfirmationToken();

            var user = new User(
                Name.Create(userDto.FirstName, userDto.LastName),
                UserEmail.Create(userDto.Email, emailConfirmationToken),
                Phone.Create(userDto.Phone),
                Password.Create(hash, salt),
                userRole
            );

            await _userManager.CreateAsync(user);
        }



        public async Task<string> LoginAsync(UserLoginDto userDto)
        {
            var user = await _userManager.FindAsync(x => x.Email.NormalizedEmail == userDto.Email.ToUpper());

            if (user is null)
            {
                _logger.LogError($"Can't find user with email: {userDto.Email}");
                throw new NotFoundException("Can't find this user");
            }

            var result = _passwordHasher.VerifyPassword(userDto.Password, user.Password.PasswordHash, user.Password.PasswordSalt);

            if(!result)
            {
                _logger.LogError("Invalid password");
                throw new AuthenticationException("Wrong password");
            }

            var token = _tokenGenerator.GenerateAccessToken(
                user.Id,
                user.Name.FullName,
                user.Email.Email,
                user.Role.Name.Value);

            return token;
        }

        public async Task<User> GetUserAsync(Specification<User> filter)
        {
            var user = await _userManager.FindAsync(filter.ToExpression(), true);

            if (user is null)
            {
                _logger.LogError($"Can't find this user");
                throw new NotFoundException("Can't find this user");
            }

            return user;
        }

        public async Task<T> GetUserAsync<T>(Specification<User> filter)
        {
            var user = await GetUserAsync(filter);

            return _mapper.Map<User,T>(user);
        }

        public async Task<bool> IsUserInRoleAsync(Guid userId, RoleName roleName)
        {
            return await _userManager.IsUserInRoleAsync(userId, roleName);
        }

        public async Task ConfirmUserEmailAsync(Guid userId, string token)
        {
            var user = await _userManager.FindAsync(x => x.Id == userId && x.Email.IsEmailConfirmed == false, true);

            if (user is null)
            {
                _logger.LogError($"Can't find this user or user email is already confirmed");
                throw new NotFoundException("Can't find this user or user email is already confirmed");
            }

            var result = await _userManager.ConfirmEmail(user, token);

            if (!result)
            {
                throw new ServerErrorException("Failed to confirm user email");
            }
        }
    }
}
