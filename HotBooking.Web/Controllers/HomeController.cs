using HotBooking.Core.Interfaces;
using HotBooking.Core.Interfaces.ValidationInterfaces;
using HotBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class HomeController : Controller
{
    public const string Name = "Home";

    private readonly IHotelsService hotelsService;
    private readonly IHotelValidationService hotelValidationService;
    private readonly IBookingValidationService bookingValidationService;

    public HomeController(IHotelsService hotelsService,
        IHotelValidationService hotelValidationService,
        IBookingValidationService bookingValidationService)
    {
        this.hotelsService = hotelsService;
        this.hotelValidationService = hotelValidationService;
        this.bookingValidationService = bookingValidationService;
    }

    public IActionResult Index()
    {
        var viewModel = new SearchHotelsViewModel()
        {
            CheckInDate = DateTime.Today.AddDays(1),
            CheckOutDate = DateTime.Today.AddDays(7)
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Index(SearchHotelsViewModel viewModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(viewModel);
        }

        var SearchObj = new
        {
            city = viewModel.City,
            checkInDate = viewModel.CheckInDate,
            checkOutDate = viewModel.CheckOutDate,
            adultsCount = viewModel.AdultsCount
        };

        return RedirectToAction("Index", "Hotels", SearchObj);
    }

    public async Task<IActionResult> Cities(string searchTerm)
    {
        var cities = await hotelsService.GetHotelsCitiesAsync(searchTerm);

        return Json(cities);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int statusCode, string message)
    {
        if (statusCode == 404)
        {
            return View("Error404", message);
        }

        if (statusCode == 401)
        {
            return View("Error401", message);
        }

        if (statusCode == 400)
        {
            return View("Error400", message);
        }

        return View("Error", message);
    }
}
