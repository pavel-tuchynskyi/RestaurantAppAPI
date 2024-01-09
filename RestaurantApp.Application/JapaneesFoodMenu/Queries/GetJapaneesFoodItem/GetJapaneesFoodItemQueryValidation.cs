using FluentValidation;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFoodItem
{
    public class GetJapaneesFoodItemQueryValidation<T> : AbstractValidator<GetJapaneesFoodItemQuery<T>>
        where T : JapaneesFood
    {
        public GetJapaneesFoodItemQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
