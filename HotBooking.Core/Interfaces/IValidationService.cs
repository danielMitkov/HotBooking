namespace HotBooking.Core.Interfaces;

public interface IValidationService
{
    bool IsDateNotInThePast(DateTime date);
    bool IsCheckOutAfterCheckIn(DateTime checkInDate, DateTime checkOutDate);
    string? AreDatesValid(DateTime checkInDate, DateTime checkOutDate);
    Task<string?> IsCityFoundAsync(string city);
}
