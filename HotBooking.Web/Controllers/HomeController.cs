using HotBooking.Core.Interfaces;
using HotBooking.Web.Constants;
using HotBooking.Web.Models;
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
        if (User.IsInRole(AdminConstants.AdminRoleName))
        {
            return RedirectToAction("Index", "Features", new { Area = AdminConstants.AdminAreaName });
        }

        var searchModel = new SearchHotelsViewModel()
        {
            CheckInDate = new DateTime(2024, 6, 17),
            CheckOutDate = new DateTime(2024, 6, 20),
            AdultsCount = 2,
            RoomsCount = 1
        };

        return View(searchModel);
    }

    [HttpPost]
    public IActionResult Index(SearchHotelsViewModel searchModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(searchModel);
        }

        return RedirectToAction(nameof(HotelsController.List), HotelsController.Name, searchModel);
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
