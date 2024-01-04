using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.MenuItems.ValueObjects
{
    public class Price : ValueObject
    {
        public decimal Value { get; private set; }

        protected Price() { }
        private Price(decimal value) : this()
        {
            Value = value;
        }

        public static Price Create(decimal value)
        {
            Guard.Is(value, nameof(Price)).MoreThan(0);

            return new Price(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static Price operator +(Price left, Price right)
        {
            return Create(left.Value + right.Value);
        }

        public static Price operator +(Price left, decimal right)
        {
            return Create(left.Value + right);
        }

        public static Price operator -(Price left, Price right)
        {
            return Create(left.Value - right.Value);
        }
    }
}
