using FluentValidation;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFood
{
    public class GetJapaneesFoodQueryValidation<T> : AbstractValidator<GetJapaneesFoodQuery<T>>
        where T : JapaneesFood
    {
        public GetJapaneesFoodQueryValidation()
        {
            RuleFor(x => x.Search.SearchTerm).NotNull();
            RuleFor(x => x.Search.SearchParameter).NotNull();
            RuleFor(x => x.Paging.PageNumber).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Paging.PageSize).GreaterThan(0);
            RuleFor(x => x.OrderBy.Value).NotNull();
        }
    }
}
