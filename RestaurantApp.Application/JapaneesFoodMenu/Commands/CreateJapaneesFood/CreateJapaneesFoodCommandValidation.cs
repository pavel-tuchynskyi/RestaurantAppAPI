using FluentValidation;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood
{
    public class CreateJapaneesFoodCommandValidation<T> : AbstractValidator<CreateJapaneesFoodCommand<T>>
        where T : JapaneesFood
    {
        public CreateJapaneesFoodCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Image.Length).LessThan(Image.IMAGE_MAX_LENGHT);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }

    public class CreateRollsCommandValidation : CreateJapaneesFoodCommandValidation<Rolls>
    {
        public CreateRollsCommandValidation()
        {
            RuleFor(x => x.Components).NotEmpty();
        }
    }

    public class CreateSusiCommandValidation : CreateJapaneesFoodCommandValidation<Susi>
    {
        public CreateSusiCommandValidation()
        {
            RuleFor(x => x.Components).NotEmpty();
        }
    }

    public class CreateSetCommandValidation : CreateJapaneesFoodCommandValidation<Set>
    {
        public CreateSetCommandValidation()
        {
            RuleFor(x => x.Components).NotEmpty();
        }
    }
}
