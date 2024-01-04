using RestaurantApp.Domain.Common.Exceptions;

namespace RestaurantApp.Application.Common.Exceptions
{
    public class ForbiddenRequestException : ExceptionBase
    {
        public override string Type => "Forbidden request";
        public override int StatusCode => 403;
        public override string Title => "Forbidden request";
        public ForbiddenRequestException(string message) : base(message)
        {
        }
    }
}
