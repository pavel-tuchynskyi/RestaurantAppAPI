using MediatR;

namespace RestaurantApp.Application.DrinkMenu.Commands.DeleteDrinkItem
{
    public record DeleteDrinkItemCommand (Guid Id) : IRequest<Unit>;
}
