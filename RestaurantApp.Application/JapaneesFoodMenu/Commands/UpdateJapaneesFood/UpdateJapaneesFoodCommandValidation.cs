using FluentValidation;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.UpdateJapaneesFood
{
    public class UpdateJapaneesFoodCommandValidation : AbstractValidator<UpdateJapaneesFoodCommand>
    {
        public UpdateJapaneesFoodCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Image.Length).LessThan(Image.IMAGE_MAX_LENGHT);
        }
    }
}
