using System.Text.RegularExpressions;

namespace RestaurantApp.Domain.Utils
{
    public class PhoneParser
    {
        public static bool TryParse(string phone, out string phoneParsed)
        {
            phoneParsed = string.Empty;

            if(string.IsNullOrWhiteSpace(phone))
                return false;

            phone = phone.Trim(' ', '-');

            if(!Regex.IsMatch(phone, @"^\+\d{12}$"))
                return false;

            phoneParsed = phone;

            return true;
        }
    }
}
