using FluentValidation;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem
{
    public class GetDrinkItemQueryValidation<T> : AbstractValidator<GetDrinkItemQuery<T>>
        where T : DrinkMenuItem
    {
        public GetDrinkItemQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
