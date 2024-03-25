namespace HotBooking.Core.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string restOfTheMessage)
        : base("Unexpected error occured while trying to " + restOfTheMessage)
    {
    }
}
