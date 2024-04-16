namespace HotBooking.Core.Exceptions;

public class InvalidModelDataException : Exception
{
    public string PropertyName { get; protected set; }

    public InvalidModelDataException(string message) : base(message)
    {
        PropertyName = string.Empty;
    }

    public InvalidModelDataException(string propertyName, string message) : base(message)
    {
        PropertyName = propertyName;
    }
}
