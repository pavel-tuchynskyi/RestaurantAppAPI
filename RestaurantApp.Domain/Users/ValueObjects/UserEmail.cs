using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;
using IvalidDataException = RestaurantApp.Domain.Common.Exceptions.InvalidDataException;

namespace RestaurantApp.Domain.Users.ValueObjects
{
    public class UserEmail : ValueObject
    {
        public string Email { get; private set; }
        public string NormalizedEmail { get; private set; }
        public bool IsEmailConfirmed { get; private set; }
        public string EmailConfirmationToken { get; private set; }

        protected UserEmail() { }
        private UserEmail(string email, bool isConfirmed, string confirmationToken) : this()
        {
            Email = email;
            NormalizedEmail = Email.ToUpper();
            IsEmailConfirmed = isConfirmed;
            EmailConfirmationToken = confirmationToken;
        }

        public static UserEmail Create(string email, string confirmationToken)
        {
            if (!EmailParser.TryParse(email, out string emailParsed))
                throw new IvalidDataException("Invalid email address");

            return new UserEmail(emailParsed, false, confirmationToken);
        }

        internal UserEmail Confirm(string token)
        {
            Guard.Is(token, nameof(token)).NotNullOrWhitespace();

            if(EmailConfirmationToken != token)
            {
                throw new IvalidDataException("Invalid email confirmation token");
            }

            return new UserEmail(Email, true, token);
        }


        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
        }

        public static implicit operator string(UserEmail email)
        {
            return email.NormalizedEmail;
        }
    }
}
