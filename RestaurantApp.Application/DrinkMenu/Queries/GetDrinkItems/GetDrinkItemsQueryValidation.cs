using FluentValidation;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItems
{
    public class GetDrinkItemsQueryValidation<T> : AbstractValidator<GetDrinkItemsQuery<T>>
        where T : DrinkMenuItem
    {
        public GetDrinkItemsQueryValidation()
        {
            RuleFor(x => x.Search.SearchTerm).NotNull();
            RuleFor(x => x.Search.SearchParameter).NotNull();
            RuleFor(x => x.Paging.PageNumber).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Paging.PageSize).GreaterThan(0);
            RuleFor(x => x.OrderBy.Value).NotNull();
        }
    }
}
