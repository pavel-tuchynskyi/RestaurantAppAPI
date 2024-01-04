using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Commands.CreateDrinkItem
{
    public record CreateDrinkItemCommand<T>(
        string Name,
        IFormFile Image,
        decimal Price,
        string Description) : IRequest<Unit>
        where T : DrinkMenuItem;
}
