using FluentValidation;
using RestaurantApp.Domain.MenuItems.Entities;

namespace RestaurantApp.Application.Ingridients.Queries.GetIngridients
{
    public class GetIngridientsQueryValidation<T> : AbstractValidator<GetIngridientsQuery<T>>
        where T : Ingridient
    {
        public GetIngridientsQueryValidation()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}
