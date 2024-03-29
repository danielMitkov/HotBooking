namespace HotBooking.Core.Exceptions;

public class KnownValidationException : Exception
{
    public KnownValidationException(string message) : base(message)
    {
    }
}
