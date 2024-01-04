using MediatR;
using Microsoft.AspNetCore.Http;

namespace RestaurantApp.Application.DrinkMenu.Commands.UpdateDrinkItem
{
    public record UpdateDrinkItemCommand(
        Guid Id,
        string Name,
        IFormFile Image,
        decimal Price,
        string Description)
        : IRequest<Unit>;
}
