using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Web.Models;
using HotBooking.Web.Models.HotelViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class HotelsController : Controller
{
    public const string Name = "Hotels";

    private readonly IHotelsService hotelsService;

    public HotelsController(IHotelsService hotelsService)
    {
        this.hotelsService = hotelsService;
    }

    [HttpPost]
    public async Task<IActionResult> Index(BrowseHotelsViewModel model)
    {
        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        BrowseHotelsInputDto inputDto = new(
            model.Page,
            1,
            model.Search.City,
            model.Search.CheckInDate,
            model.Search.CheckOutDate,
            model.Search.AdultsCount,
            model.Search.RoomsCount,
            model.Sorting,
            model.SelectedFacilityIds);

        BrowseHotelsOutputDto outputDto;

        try
        {
            outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);
        }
        catch(CityNotFound ex)
        {
            ModelState.AddModelError(nameof(model.Search.City), ex.Message);
            return View(model);
        }

        model.Pager = new(outputDto.TotalPages, model.Page, Name, nameof(Index));
        model.Hotels = outputDto.SelectedHotels;
        model.Facilities = outputDto.Facilities;
        model.AllHotelsCount = outputDto.AllHotelsCount;

        return View(model);
    }

    public async Task<IActionResult> Details(string publidId, SearchHotelsViewModel search)
    {
        return View();
    }
}
