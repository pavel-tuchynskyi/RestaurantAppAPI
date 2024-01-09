using FluentValidation;
using RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem;

namespace RestaurantApp.Application.ItalianFoodMenu.Queries.GetItalianFoodItem
{
    public class GetItalianFoodItemQueryValidation : AbstractValidator<GetDrinkItemQuery>
    {
        public GetItalianFoodItemQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
