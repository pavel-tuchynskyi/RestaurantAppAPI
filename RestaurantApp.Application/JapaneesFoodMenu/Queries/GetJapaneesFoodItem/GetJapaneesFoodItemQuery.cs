using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFoodItem
{
    public record GetJapaneesFoodItemQuery<T> (Guid Id) : IRequest<FoodItemDto>
        where T : JapaneesFood;
}
