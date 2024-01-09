using FluentValidation;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem
{
    public class GetDrinkItemQueryValidation : AbstractValidator<GetDrinkItemQuery>
    {
        public GetDrinkItemQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
