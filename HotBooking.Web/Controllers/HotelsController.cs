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

    [Route("Hotels/List/{page?}")]
    public async Task<IActionResult> List(BrowseHotelsViewModel model)
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
        catch (CityNotFound ex)
        {
            ModelState.AddModelError(nameof(model.Search.City), ex.Message);
            return View(model);
        }

        model.Pager = new(outputDto.TotalPages, model.Page);
        model.Hotels = outputDto.SelectedHotels;
        model.Facilities = outputDto.Facilities;
        model.AllHotelsCount = outputDto.AllHotelsCount;

        return View(model);
    }

    public async Task<IActionResult> Details(Guid id, SearchHotelsViewModel search)
    {
        HotelDetailsDtoInput inputDto = new(
            id,
            search.AdultsCount,
            search.RoomsCount,
            search.CheckInDate,
            search.CheckOutDate);

        HotelDetailsDtoOutput? hotelDto = await hotelsService.GetHotelDetailsAsync(inputDto);

        if (hotelDto == null)
        {
            TempData["Error"] = "Hotel Not Found!";
            return BadRequest();
        }

        HotelDetailsViewModel model = new()
        {
            HotelId = id,
            Search = search,
            Hotel = hotelDto
        };

        return View(model);
    }
}
