namespace HotBooking.Core.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException() : base("Unexpected error occured.")
    {
    }
}
