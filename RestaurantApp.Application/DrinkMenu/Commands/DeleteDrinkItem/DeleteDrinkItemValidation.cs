using FluentValidation;

namespace RestaurantApp.Application.DrinkMenu.Commands.DeleteDrinkItem
{
    public class DeleteDrinkItemValidation : AbstractValidator<DeleteDrinkItemCommand>
    {
        public DeleteDrinkItemValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
