using FluentValidation;
using RestaurantApp.Domain.MenuItems.Food.Italian;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.CreateItalianFood
{
    public class CreateItalianFoodCommandValidation<T> : AbstractValidator<CreateItalianFoodCommand<T>>
        where T : ItalianFood
    {
        public CreateItalianFoodCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Image.Length).LessThan(Image.IMAGE_MAX_LENGHT);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }

    public class CreatePizzaCommandValidation : CreateItalianFoodCommandValidation<Pizza>
    {
        public CreatePizzaCommandValidation()
        {
            RuleFor(x => x.Components).NotEmpty();
        }
    }
}
