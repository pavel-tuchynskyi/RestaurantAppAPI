using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.ValueObjects;
using System.Diagnostics;
using System.Linq.Expressions;

namespace RestaurantApp.Application.Common.Specifications.MenuItemSpecification
{
    public class MenuItemSearchSpecification<T> : Specification<T>
        where T : MenuItem
    {
        private readonly string _searhParameter;
        private readonly string _value;

        public MenuItemSearchSpecification(string searhParameter, string value)
        {
            _searhParameter = searhParameter;
            _value = value;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            if(string.IsNullOrEmpty(_searhParameter) || string.IsNullOrEmpty(_value))
            {
                return x => true;
            }

            var prop = typeof(T).GetProperties().FirstOrDefault(x => x.Name == _searhParameter).Name;

            return prop switch
            {
                nameof(MenuItem.Name) => new SearchNameSpecification<T>(_value).ToExpression(),
                _ => throw new UnreachableException()
            };
        }
    }

    public class SearchNameSpecification<T> : Specification<T>
        where T : MenuItem
    {
        private readonly string _value = string.Empty;

        public SearchNameSpecification(string value)
        {
            _value = value;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return item => item.Name == ItemName.Create(_value);
        }
    }
}
