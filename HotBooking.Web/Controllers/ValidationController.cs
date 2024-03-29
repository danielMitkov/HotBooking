using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Interfaces.ValidationInterfaces;
using HotBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
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

    public async Task<IActionResult> CityExists(SearchHotelsViewModel search)
    {
        return Json((await hotelValidationService.IsCityFoundAsync(search.City)) ? true : HotelErrors.CityNotFound);
    }

    public IActionResult AreDatesValid(DateTime checkInDate, DateTime checkOutDate)
    {
        string? errorMsg = bookingValidationService.AreDatesValid(checkInDate, checkOutDate);

        return Json(errorMsg == null ? true : errorMsg);
    }
}
