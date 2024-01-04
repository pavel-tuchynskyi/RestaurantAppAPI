using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.MenuItems.ValueObjects
{
    public class Description : ValueObject
    {
        public string Value { get; private set; }

        protected Description() { }
        private Description(string value) : this()
        {
            Value = value;
        }

        public static Description Create(string value) 
        { 
            Guard.Is(value, nameof(Description)).NotNullOrWhitespace();

            return new Description(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
