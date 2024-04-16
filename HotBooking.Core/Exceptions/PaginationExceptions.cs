namespace HotBooking.Core.Exceptions;

public class PageOutOfRangeException : InvalidModelDataException
{
    public PageOutOfRangeException(int maxPage)
        : base(string.Empty, $"Page number must between 1 and {maxPage}")
    {
    }
}
