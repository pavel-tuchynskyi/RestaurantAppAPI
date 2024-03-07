using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RestaurantApp.Application.Common.Models;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantApp.Infrastructure.Authentication
{
    public class TokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        public TokenGenerator(IOptions<JwtSettings> jwtSettingsOptions)
        {
            _jwtSettings = jwtSettingsOptions.Value;
        }

        public AccessToken GenerateAccessToken(Guid userId, string fullName, string email, string role)
        {
            var signingCredentials = GetSignInCredentials();
            var claims = GetClaims(userId, fullName, email, role);
            var accessToken = GenerateToken(signingCredentials, claims);

            return new AccessToken(new JwtSecurityTokenHandler().WriteToken(accessToken));
        }

        private SigningCredentials GetSignInCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(Guid userId, string fullName, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, fullName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            return claims;
        }

        private JwtSecurityToken GenerateToken(SigningCredentials creds, List<Claim> claims)
        {
            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: creds);

            return securityToken;
        }

        public string GenerateEmailConfirmationToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] tokenData = new byte[32];

                rng.GetBytes(tokenData);

                return Convert.ToBase64String(tokenData);
            }
        }
    }
}
