using RestaurantApp.Domain.Users;
using System.Linq.Expressions;

namespace RestaurantApp.Application.Common.Specifications.AccountSpecification
{
    public class GetUserByIdSpecification : Specification<User>
    {
        private readonly Guid _id;

        public GetUserByIdSpecification(Guid id)
        {
            _id = id;
        }
        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Id == _id;
        }
    }
}
