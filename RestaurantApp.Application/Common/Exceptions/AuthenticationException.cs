using RestaurantApp.Domain.Common.Exceptions;

namespace RestaurantApp.Application.Common.Exceptions
{
    public class AuthenticationException : ExceptionBase
    {
        public override string Type => "Authentication error";
        public override int StatusCode => 401;
        public override string Title => "Authentication error";
        public AuthenticationException(string message) : base(message)
        {
        }
    }
}
