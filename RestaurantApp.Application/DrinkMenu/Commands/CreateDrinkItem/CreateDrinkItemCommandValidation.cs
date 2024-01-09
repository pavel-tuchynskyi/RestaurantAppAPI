using FluentValidation;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.DrinkMenu.Commands.CreateDrinkItem
{
    public class CreateDrinkItemCommandValidation<T> : AbstractValidator<CreateDrinkItemCommand<T>>
        where T : DrinkMenuItem
    {
        public CreateDrinkItemCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Image.Length).LessThan(Image.IMAGE_MAX_LENGHT);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
