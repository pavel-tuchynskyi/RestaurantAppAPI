using AutoMapper;
using RestaurantApp.Application.Common.DTOs.Account;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Application.Common.Specifications;
using RestaurantApp.Domain.Users;
using RestaurantApp.Domain.Users.ValueObjects;
using RestaurantApp.Infrastructure.Authentication;
using RestaurantApp.Infrastructure.Common.Interfaces.Authentication;

namespace RestaurantApp.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserManager _userManager;
        private readonly PasswordHasher _passwordHasher;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IRoleManager _roleManager;
        private readonly IMapper _mapper;

        public AccountService(IUserManager userManager, 
            PasswordHasher passwordHasher, 
            JwtTokenGenerator jwtTokenGenerator,
            IRoleManager roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task RegisterAsync(UserCreateDto userDto)
        {
            if (await _userManager.UserExistedAsync(userDto.Email))
            {
                throw new Exception("User already exist");
            }

            var hash = _passwordHasher.HashPasword(userDto.Password, out var salt);

            var user = new User(
                Name.Create(userDto.FirstName, userDto.LastName),
                UserEmail.Create(userDto.Email),
                Phone.Create(userDto.Phone),
                Password.Create(hash, salt)
            );

            var userRole = await _roleManager.GetByNameAsync(RoleName.User);

            user.AddToRole(userRole);

            await _userManager.CreateAsync(user);
        }

        public async Task<string> LoginAsync(UserLoginDto userDto)
        {
            var user = await _userManager.FindAsync(x => x.Email.NormalizedEmail == userDto.Email.ToUpper());

            if (user is null)
            {
                throw new NotFoundException("Can't find this user");
            }

            var result = _passwordHasher.VerifyPassword(userDto.Password, user.Password.PasswordHash, user.Password.PasswordSalt);

            if(!result)
            {
                throw new AuthenticationException("Wrong password");
            }

            var token = _jwtTokenGenerator.GenerateAccessToken(
                user.Id,
                user.Name.FullName,
                user.Email.Email,
                user.Role.Name.Value);

            return token;
        }

        public async Task<User> GetUserAsync(Specification<User> filter)
        {
            var user = await _userManager.FindAsync(filter.ToExpression(), true);

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
    }
}
