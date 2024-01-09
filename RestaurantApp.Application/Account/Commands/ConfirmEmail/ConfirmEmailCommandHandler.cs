using MediatR;
using RestaurantApp.Application.Common.Interfaces.Account;

namespace RestaurantApp.Application.Account.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Unit>
    {
        private readonly IAccountService _accountService;

        public ConfirmEmailCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            await _accountService.ConfirmUserEmailAsync(request.Id, request.Token);

            return Unit.Value;
        }
    }
}
