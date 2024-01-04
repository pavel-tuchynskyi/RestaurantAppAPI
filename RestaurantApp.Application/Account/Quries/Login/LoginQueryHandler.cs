using MediatR;
using RestaurantApp.Application.Common.DTOs.Account;
using RestaurantApp.Application.Common.Interfaces.Account;

namespace RestaurantApp.Application.Account.Quries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IAccountService _accountService;

        public LoginQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userDto = new UserLoginDto(request.Email, request.Password);
            var token = await _accountService.LoginAsync(userDto);
            return token;
        }
    }
}
