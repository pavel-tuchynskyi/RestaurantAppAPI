using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.Users.ValueObjects
{
    public class Password : ValueObject
    {
        public string PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        protected Password() { }
        private Password(string passwordHash, byte[] passwordSalt) : this()
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        } 

        public static Password Create(string hash, byte[] salt)
        {
            Guard.Is(hash, nameof(PasswordHash)).NotNullOrWhitespace();
            Guard.Is(salt, nameof(PasswordSalt)).NotNullOrEmpty();

            return new Password(hash, salt);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return PasswordHash;
        }
    }
}
