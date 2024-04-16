namespace HotBooking.Core.ErrorMessages;
public static class BookingErrors
{
    public const string InThePastCheckIn = "Check-in date cannot be in the past.";
    public const string InThePastCheckOut = "Check-out date cannot be in the past.";

    public const string CheckInDateAfterCheckOutDate = "Check-out date must be after check-in date.";

    public const string NotFound = "Booking Not Found!";
}
