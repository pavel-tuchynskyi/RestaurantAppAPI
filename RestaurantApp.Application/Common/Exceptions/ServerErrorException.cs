using RestaurantApp.Domain.Common.Exceptions;

namespace RestaurantApp.Application.Common.Exceptions
{
    public class ServerErrorException : ExceptionBase
    {
        public override string Type => "Internal server error";
        public override int StatusCode => 500;
        public override string Title => "Internal server error";
        public ServerErrorException(string message) : base(message)
        {
        }
    }
}
