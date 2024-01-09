using FluentValidation;

namespace RestaurantApp.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Items).NotEmpty();
        }
    }
}
