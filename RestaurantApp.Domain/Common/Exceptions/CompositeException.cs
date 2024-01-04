namespace RestaurantApp.Domain.Common.Exceptions
{
    public class CompositeException : ExceptionBase
    {
        private Stack<ExceptionBase> InnerExceptions { get; set; } = new Stack<ExceptionBase>();

        public CompositeException(string title, string message) : base(title, message)
        {
        }
        public CompositeException(string type, int statusCode, string title, string message) : base(title, message)
        {
            Type = type;
            StatusCode = statusCode;
        }

        public override void Push(ExceptionBase exception)
        {
            InnerExceptions.Push(exception);
        }

        public override ExceptionBase Pop()
        {
            if (InnerExceptions.Count > 0)
            {
                return InnerExceptions.Pop();
            }

            return Empty;
        }
    }
}
