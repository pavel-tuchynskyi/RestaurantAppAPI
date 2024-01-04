namespace RestaurantApp.Domain.Common.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public static NullException Empty => new NullException();
        public virtual string Type { get; set; } = null!;
        public virtual int StatusCode { get; set; }
        public virtual string Title { get; set; } = null!;

        protected ExceptionBase() { }
        public ExceptionBase(string message) : base(message)
        { 
        }

        public ExceptionBase(string title, string message) : this(message)
        {
            Title = title;
        }

        public virtual void Push(ExceptionBase exception) 
        {
            return;
        }

        public virtual ExceptionBase Pop()
        {
            return Empty;
        }
    }
}
