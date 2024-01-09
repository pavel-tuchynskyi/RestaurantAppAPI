using FluentValidation;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.DrinkMenu.Commands.UpdateDrinkItem
{
    public class UpdateDrinkItemCommandValidation : AbstractValidator<UpdateDrinkItemCommand>
    {
        public UpdateDrinkItemCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Image.Length).LessThan(Image.IMAGE_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
