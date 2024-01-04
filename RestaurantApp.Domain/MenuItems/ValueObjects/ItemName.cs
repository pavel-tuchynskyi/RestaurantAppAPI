using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.MenuItems.ValueObjects
{
    public class ItemName : ValueObject
    {
        public string Value { get; private set; }

        protected ItemName() { }
        private ItemName(string value) : this()
        {
            Value = value;
        }

        public static ItemName Create(string name)
        {
            Guard.Is(name, nameof(ItemName)).NotNullOrWhitespace();

            name = name.Trim();

            return new ItemName(name);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
