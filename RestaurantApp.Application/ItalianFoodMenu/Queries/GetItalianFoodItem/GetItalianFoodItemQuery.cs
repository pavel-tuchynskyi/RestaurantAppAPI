using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Queries.GetFoodItem
{
    public record GetItalianFoodItemQuery<T> (Guid Id) : IRequest<FoodItemDto>
        where T : ItalianFood;
}
