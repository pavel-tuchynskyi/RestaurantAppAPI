using FluentValidation;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Ingridients.Command.CreateIngridient
{
    public class CreateIngridientCommandValidation<T> : AbstractValidator<CreateIngridientCommand<T>>
        where T : Ingridient
    {
        public CreateIngridientCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Image.Length).LessThan(Image.IMAGE_MAX_LENGHT);
        }
    }
}
