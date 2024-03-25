namespace HotBooking.Core.ErrorMessages;
public static class BookingErrors
{
    public const string CheckInDateInThePast = "Check-in date cannot be in the past.";
    public const string CheckOutDateInThePast = "Check-out date cannot be in the past.";

    public const string CheckInDateAfterCheckOutDate = "Check-out date must be after check-in date.";
}
