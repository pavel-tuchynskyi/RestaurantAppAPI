using FluentValidation;
using RestaurantApp.Application.ItalianFoodMenu.Queries.GetFoodItem;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Queries.GetItalianFoodItem
{
    public class GetItalianFoodItemQueryValidation<T> : AbstractValidator<GetItalianFoodItemQuery<T>>
        where T : ItalianFood
    {
        public GetItalianFoodItemQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
