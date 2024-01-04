using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;
using IvalidDataException = RestaurantApp.Domain.Common.Exceptions.InvalidDataException;

namespace RestaurantApp.Domain.Users.ValueObjects
{
    public class Phone : ValueObject
    {
        public string PhoneNumber { get; private set; }

        protected Phone() { }
        private Phone(string phoneNumber) : this()
        {
            PhoneNumber = phoneNumber;
        }

        public static Phone Create(string phoneNumber)
        {
            if (!PhoneParser.TryParse(phoneNumber, out string phoneNumberParsed))
                throw new IvalidDataException("Invalid phone number");

            return new Phone(phoneNumberParsed);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhoneNumber;
        }
    }
}
