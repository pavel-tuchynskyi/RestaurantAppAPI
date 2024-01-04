using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.Orders.ValueObjects
{
    public class OrderAddress : ValueObject
    {
        public string City { get; private set; }
        public string Address { get; private set; }

        protected OrderAddress() { }
        private OrderAddress(string city, string address) : this()
        {
            City = city;
            Address = address;
        }

        public static OrderAddress Create(string city, string address)
        {
            Guard.Is(city, nameof(City)).NotNullOrWhitespace();
            Guard.Is(address, nameof(Address)).NotNullOrWhitespace();

            city = city.Trim();
            address = address.Trim();

            return new OrderAddress(city, address);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Address;
        }
    }
}
