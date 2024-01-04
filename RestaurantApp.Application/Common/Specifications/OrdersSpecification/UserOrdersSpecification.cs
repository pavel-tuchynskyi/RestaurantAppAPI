using RestaurantApp.Domain.Orders;
using System.Linq.Expressions;

namespace RestaurantApp.Application.Common.Specifications.OrdersSpecification
{
    public class UserOrdersSpecification : Specification<Order>
    {
        private readonly Guid _createdBy;

        public UserOrdersSpecification(Guid createdBy)
        {
            _createdBy = createdBy;
        }
        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.CreatedBy.Id == _createdBy;
        }
    }
}
