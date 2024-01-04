using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFood
{
    public record GetJapaneesFoodQuery<T>
        : QueryParameters,
        IRequest<PagedList<FoodItemDto>>
        where T : JapaneesFood
    {
        public GetJapaneesFoodQuery(Search SearchTerm, OrderBy OrderBy, Paging Paging) : base(SearchTerm, OrderBy, Paging)
        {
        }
    }
}
