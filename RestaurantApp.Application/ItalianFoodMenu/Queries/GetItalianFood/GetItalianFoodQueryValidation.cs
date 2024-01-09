using FluentValidation;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Queries.GetItalianFood
{
    public class GetItalianFoodQueryValidation<T> : AbstractValidator<GetItalianFoodQuery<T>>
        where T : ItalianFood
    {
        public GetItalianFoodQueryValidation()
        {
            RuleFor(x => x.Search.SearchTerm).NotNull();
            RuleFor(x => x.Search.SearchParameter).NotNull();
            RuleFor(x => x.Paging.PageNumber).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Paging.PageSize).GreaterThan(0);
            RuleFor(x => x.OrderBy.Value).NotNull();
        }
    }
}
