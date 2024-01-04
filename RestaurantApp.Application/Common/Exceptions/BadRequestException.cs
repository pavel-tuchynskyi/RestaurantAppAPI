using RestaurantApp.Domain.Common.Exceptions;

namespace RestaurantApp.Application.Common.Exceptions
{
    public class BadRequestException : ExceptionBase
    {
        public override string Type => "Bad request";
        public override int StatusCode => 400;
        public override string Title => "Bad request";
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
