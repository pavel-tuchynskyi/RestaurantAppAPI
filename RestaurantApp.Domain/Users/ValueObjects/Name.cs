using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.Users.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => string.Format("{0} {1}", FirstName, LastName);
        protected Name() { }
        private Name(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Name Create(string firstName, string lastName)
        {
            Guard.Is(firstName, nameof(FirstName)).NotNullOrWhitespace();
            Guard.Is(lastName, nameof(LastName)).NotNullOrWhitespace();

            firstName = firstName.Trim();
            lastName = lastName.Trim();

            Guard.Is(firstName, nameof(FirstName)).LengthLessThan(30);
            Guard.Is(lastName, nameof(LastName)).LengthLessThan(30);

            return new Name(firstName, lastName);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
