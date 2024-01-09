using FluentValidation;

namespace RestaurantApp.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidation : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
