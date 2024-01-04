using Microsoft.Extensions.Options;
using RestaurantApp.Infrastructure.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantApp.Infrastructure.Authentication
{
    public class PasswordHasher
    {
        private readonly PasswordHasherSettings _hasherSettings;
        public PasswordHasher(IOptions<PasswordHasherSettings> options)
        {
            _hasherSettings = options.Value;
        }

        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(_hasherSettings.KeySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password), 
                salt, _hasherSettings.Iterations, 
                new HashAlgorithmName(_hasherSettings.Algorithm), 
                _hasherSettings.KeySize);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                password, 
                salt, 
                _hasherSettings.Iterations, 
                new HashAlgorithmName(_hasherSettings.Algorithm), 
                _hasherSettings.KeySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
