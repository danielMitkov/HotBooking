using HotBooking.Core.Interfaces;
using HotBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
public class ValidationController : Controller
{
    public const string Name = "Validation";

    private readonly IValidationService validationService;

    public ValidationController(IValidationService validationService)
    {
        this.validationService = validationService;
    }

    public async Task<IActionResult> CityExists(SearchHotelsViewModel search)
    {
        string? errorMessage = await validationService.IsCityFoundAsync(search.City);

        return Json(errorMessage == null ? true : errorMessage);
    }

    public IActionResult AreDatesValid(DateTime checkInDate, DateTime checkOutDate)
    {
        string? errorMessage = validationService.AreDatesValid(checkInDate, checkOutDate);

        return Json(errorMessage == null ? true : errorMessage);
    }
}
