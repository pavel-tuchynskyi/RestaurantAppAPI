using RestaurantApp.Domain.Common.Exceptions;

namespace RestaurantApp.Application.Common.Exceptions
{
    public class ValidationException : ExceptionBase
    {
        public override string Type => "Validation error";
        public override int StatusCode => 403;
        public override string Title => "Validation error";
        public ValidationException(string message) : base(message)
        {
        }
    }
}
