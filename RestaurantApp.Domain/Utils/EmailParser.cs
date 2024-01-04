using System.Text.RegularExpressions;

namespace RestaurantApp.Domain.Utils
{
    public class EmailParser
    {
        public static bool TryParse(string email, out string emailParsed)
        {
            emailParsed = string.Empty;

            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.ToLower().Trim();

            if(!Regex.IsMatch(email, "^([^\\.\\.]+[A-Za-z0-9-+.])+[^\\.\\.]+@[^-]+[A-Za-z0-9-][^\\-\\-]+\\.[A-Za-z0-9]{1,3}"))
                return false;

            emailParsed = email;

            return true;
        }
    }
}
