using MediatR;
using RestaurantApp.Application.Common.DTOs.Account;
using RestaurantApp.Application.Common.Interfaces.Account;

namespace RestaurantApp.Application.Account.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var dto = new UserCreateDto(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Phone,
                request.Password);

            await _accountService.RegisterAsync(dto);

            return Unit.Value;
        }
    }
}
