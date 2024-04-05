using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Interfaces;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class ValidationService : IValidationService
{
    private readonly HotBookingDbContext dbContext;

    public ValidationService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

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

    public async Task<string?> IsCityFoundAsync(string city)
    {
        city = city.ToLower();

        bool isCityFound = await dbContext.Hotels
            .AnyAsync(h => h.CityName.ToLower() == city);

        return isCityFound ? null : HotelErrors.CityNotFound;
    }
}
