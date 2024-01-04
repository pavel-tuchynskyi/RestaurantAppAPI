using RestaurantApp.Domain.Common.Exceptions;

namespace RestaurantApp.Application.Common.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public override string Type => "Not Found";
        public override int StatusCode => 404;
        public override string Title => "Not Found";
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
