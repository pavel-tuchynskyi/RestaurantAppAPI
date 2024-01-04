using RestaurantApp.Domain.Common;

namespace RestaurantApp.Domain.Users.ValueObjects
{
    public class RoleName : ValueObject
    {
        public static RoleName User = new RoleName("User");
        public static RoleName Admin = new RoleName("Admin");
        public string Value { get; private set; }

        protected RoleName() { }
        private RoleName(string value) : this()
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
