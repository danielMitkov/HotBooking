using HotBooking.Core.Enums;
using HotBooking.Core.Interfaces;
using HotBooking.Web.Models.HotelViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class HomeController : Controller
{
    public const string Name = "Home";

    private readonly IHotelsService hotelsService;

    public HomeController(IHotelsService hotelsService)
    {
        this.hotelsService = hotelsService;
    }

    public IActionResult Index()
    {
        BrowseHotelsViewModel model = new()
        {
            Search = new()
            {
                CheckInDate = new DateTime(2024, 4, 17),
                CheckOutDate = new DateTime(2024, 4, 20)
            },
            Sorting = HotelSorting.RatingDesc
        };

        return View(model);
    }

    public async Task<IActionResult> Cities(string searchTerm)
    {
        var cities = await hotelsService.GetMatchingCitiesAsync(searchTerm);

        return Json(cities);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int statusCode)
    {
        if (statusCode == 404)
        {
            return View("Error404");
        }

        if (statusCode == 401)
        {
            return View("Error401");
        }

        if (statusCode == 400)
        {
            return View("Error400");
        }

        return View("Error500");
    }
}
