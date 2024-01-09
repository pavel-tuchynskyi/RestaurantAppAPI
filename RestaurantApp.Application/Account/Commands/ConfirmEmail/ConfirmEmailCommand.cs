using MediatR;

namespace RestaurantApp.Application.Account.Commands.ConfirmEmail
{
    public record ConfirmEmailCommand(Guid Id, string Token) : IRequest<Unit>;
}
