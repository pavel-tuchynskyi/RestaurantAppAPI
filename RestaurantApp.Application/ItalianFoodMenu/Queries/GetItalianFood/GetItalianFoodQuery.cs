using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Queries.GetItalianFood
{
    public record GetItalianFoodQuery<T>
        : QueryParameters,
        IRequest<PagedList<FoodItemDto>>
        where T : ItalianFood
    {
        public GetItalianFoodQuery(Search SearchTerm, OrderBy OrderBy, Paging Paging) : base(SearchTerm, OrderBy, Paging)
        {
        }
    }
}
