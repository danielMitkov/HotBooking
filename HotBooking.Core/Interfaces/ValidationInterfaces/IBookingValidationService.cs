namespace HotBooking.Core.Interfaces.ValidationInterfaces;
public interface IBookingValidationService
{
    bool IsDateNotInThePast(DateTime date);
    bool IsCheckOutAfterCheckIn(DateTime checkInDate, DateTime checkOutDate);
    string? AreDatesValid(DateTime checkInDate, DateTime checkOutDate);
}
