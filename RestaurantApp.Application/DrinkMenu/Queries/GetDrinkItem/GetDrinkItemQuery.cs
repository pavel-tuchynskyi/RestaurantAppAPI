using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem
{
    public record GetDrinkItemQuery<T> (Guid Id) 
        : IRequest<DrinkItemDto>
        where T : DrinkMenuItem;
}
