﻿using HotBooking.Core.Interfaces;
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
            CheckInDate = new DateTime(2024, 4, 5),
            CheckOutDate = new DateTime(2024, 4, 11)
        };

        return View(viewModel);
    }

    [HttpPost]//use only if it changes db data
    public IActionResult Index(SearchHotelsViewModel model)
    {
        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        return RedirectToAction(nameof(HotelsController.Index), HotelsController.Name, model);
    }

    public async Task<IActionResult> Cities(string searchTerm)
    {
        var cities = await hotelsService.GetMatchingCitiesAsync(searchTerm);

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
