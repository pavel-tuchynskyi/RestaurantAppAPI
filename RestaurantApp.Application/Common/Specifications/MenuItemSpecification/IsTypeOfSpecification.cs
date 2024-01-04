using RestaurantApp.Domain.Common;
using System.Linq.Expressions;

namespace RestaurantApp.Application.Common.Specifications.MenuItemSpecification
{
    public class IsTypeOfSpecification<T, R> : Specification<T>
        where T : Entity
        where R : Entity
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return item => item.GetType() == typeof(R);
        }
    }
}
