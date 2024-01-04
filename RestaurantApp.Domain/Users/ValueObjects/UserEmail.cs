using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;
using IvalidDataException = RestaurantApp.Domain.Common.Exceptions.InvalidDataException;

namespace RestaurantApp.Domain.Users.ValueObjects
{
    public class UserEmail : ValueObject
    {
        public string Email { get; private set; }
        public string NormalizedEmail { get; private set; }

        protected UserEmail() { }
        private UserEmail(string email) : this()
        {
            Email = email;
            NormalizedEmail = Email.ToUpper();
        }

        public static UserEmail Create(string email)
        {
            if (!EmailParser.TryParse(email, out string emailParsed))
                throw new IvalidDataException("Invalid email address");

            return new UserEmail(emailParsed);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
        }

        public static implicit operator string(UserEmail email)
        {
            return email.NormalizedEmail;
        }

        public static explicit operator UserEmail(string v)
        {
            return new UserEmail(v);
        }
    }
}
