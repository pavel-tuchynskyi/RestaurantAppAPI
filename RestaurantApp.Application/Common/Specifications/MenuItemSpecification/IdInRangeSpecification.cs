using RestaurantApp.Domain.Common;
using System.Linq.Expressions;

namespace RestaurantApp.Application.Common.Specifications.MenuItemSpecification
{
    public class IdInRangeSpecification<T> : Specification<T>
        where T : Entity
    {
        private readonly List<Guid> _ids;

        public IdInRangeSpecification(List<Guid> ids)
        {
            _ids = ids;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return ingridient => _ids.Contains(ingridient.Id);
        }
    }
}
