using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Interfaces.ValidationInterfaces;

namespace HotBooking.Core.Services.ValidationServices;
public class BookingValidationService : IBookingValidationService
{
    public bool IsDateNotInThePast(DateTime date)
    {
        return date >= DateTime.UtcNow;
    }

    public bool IsCheckOutAfterCheckIn(DateTime checkInDate, DateTime checkOutDate)
    {
        return checkOutDate > checkInDate;
    }

    public string? AreDatesValid(DateTime checkInDate, DateTime checkOutDate)
    {
        if (IsDateNotInThePast(checkInDate) == false)
        {
            return BookingErrors.CheckInDateInThePast;
        }

        if (IsDateNotInThePast(checkOutDate) == false)
        {
            return BookingErrors.CheckOutDateInThePast;
        }

        if (IsCheckOutAfterCheckIn(checkInDate, checkOutDate) == false)
        {
            return BookingErrors.CheckInDateAfterCheckOutDate;
        }

        return null;
    }
}
