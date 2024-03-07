using MediatR;
using RestaurantApp.Application.Common.DTOs.Account;
using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Application.Common.Models;

namespace RestaurantApp.Application.Account.Quries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AccessToken>
    {
        private readonly IAccountService _accountService;

        public LoginQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<AccessToken> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userDto = new UserLoginDto(request.Email, request.Password);
            var token = await _accountService.LoginAsync(userDto);
            return token;
        }
    }
}
