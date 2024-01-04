using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem
{
    public record GetDrinkItemQuery (Guid Id) : IRequest<DrinkItemDto>;
}
