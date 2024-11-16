namespace GttpGtrpLib.Exceptions
{
    public class InvalidGttpRequestException : Exception
    {
        public InvalidGttpRequestException() 
            : base()
        { }

        public InvalidGttpRequestException(string? message)
            : base(message)
        { }

        public InvalidGttpRequestException(string? message, Exception? innerException)
            : base(message, innerException)
        { }
    }
}
