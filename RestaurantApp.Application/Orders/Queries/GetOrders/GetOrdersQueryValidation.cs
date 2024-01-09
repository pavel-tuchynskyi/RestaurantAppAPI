using FluentValidation;

namespace RestaurantApp.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryValidation : AbstractValidator<GetOrdersQuery>
    {
        public GetOrdersQueryValidation()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Paging.PageNumber).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Paging.PageSize).GreaterThan(0);
        }
    }
}
