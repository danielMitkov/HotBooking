using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Interfaces.ValidationInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;
public class ValidationController : Controller
{
    private readonly IHotelValidationService hotelValidationService;
    private readonly IBookingValidationService bookingValidationService;

    public const string Name = "Validation";

    public ValidationController(IHotelValidationService hotelValidationService,
        IBookingValidationService bookingValidationService)
    {
        this.hotelValidationService = hotelValidationService;
        this.bookingValidationService = bookingValidationService;
    }

    public async Task<IActionResult> CityExists(string city)
    {
        return Json((await hotelValidationService.IsCityFoundAsync(city)) ? true : HotelErrors.CityNotFound);
    }

    public IActionResult AreDatesValid(DateTime checkInDate, DateTime checkOutDate)
    {
        string? errorMsg = bookingValidationService.AreDatesValid(checkInDate, checkOutDate);

        return Json(errorMsg == null ? true : errorMsg);
    }
}
