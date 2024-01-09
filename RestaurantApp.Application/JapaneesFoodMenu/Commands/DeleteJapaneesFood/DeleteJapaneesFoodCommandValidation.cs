using FluentValidation;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.DeleteJapaneesFood
{
    public class DeleteJapaneesFoodCommandValidation : AbstractValidator<DeleteJapaneesFoodCommand>
    {
        public DeleteJapaneesFoodCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
