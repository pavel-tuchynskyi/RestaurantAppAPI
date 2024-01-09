using FluentValidation;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.DeleteItalianFood
{
    public class DeleteItalianFoodCommandValidation : AbstractValidator<DeleteItalianFoodCommand>
    {
        public DeleteItalianFoodCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
