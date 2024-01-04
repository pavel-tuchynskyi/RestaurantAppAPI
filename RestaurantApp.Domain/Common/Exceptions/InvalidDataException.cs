namespace RestaurantApp.Domain.Common.Exceptions
{
    public class InvalidDataException : ExceptionBase
    {
        public override string Type => "Invalid data";
        public override int StatusCode => 400;
        public override string Title => "Invalid data";

        public InvalidDataException(string message) : base(message)
        {
        }
    }
}
