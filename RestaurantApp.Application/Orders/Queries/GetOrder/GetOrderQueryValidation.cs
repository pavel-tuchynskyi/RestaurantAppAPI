using FluentValidation;

namespace RestaurantApp.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryValidation : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
