using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;
using System.Linq.Expressions;

namespace RestaurantApp.Application.Common.Specifications.MenuItemSpecification
{
    public class IngridientNameSearchSpecification<T> : Specification<T>
        where T : Ingridient
    {
        private readonly string _name;

        public IngridientNameSearchSpecification(string name)
        {
            _name = name;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return ingridient => ingridient.Name == ItemName.Create(_name);
        }
    }
}
