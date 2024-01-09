using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItems
{
    public record GetDrinkItemsQuery<T> : QueryParameters, IRequest<PagedList<DrinkItemDto>>
        where T : DrinkMenuItem
    {
        public GetDrinkItemsQuery(Search Search, OrderBy OrderBy, Paging Paging) : base(Search, OrderBy, Paging)
        {
        }
    }
}
