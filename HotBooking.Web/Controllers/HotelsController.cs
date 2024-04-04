using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Interfaces.ValidationInterfaces;
using HotBooking.Web.Models;
using HotBooking.Web.Models.HotelViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

[Authorize]
public class HotelsController : Controller
{
    public const string Name = "Hotels";

    private readonly ILogger<HotelsController> logger;

    private readonly IHotelsService hotelsService;

    private readonly IHotelValidationService hotelValidationService;
    private readonly IBookingValidationService bookingValidationService;

    public HotelsController(
        ILogger<HotelsController> logger,
        IHotelsService hotelsService,
        IHotelValidationService hotelValidationService,
        IBookingValidationService bookingValidationService)
    {
        this.logger = logger;

        this.hotelsService = hotelsService;

        this.hotelValidationService = hotelValidationService;
        this.bookingValidationService = bookingValidationService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(SearchHotelsViewModel searchModel)
    {
        BrowseHotelsViewModel browseModel = new()
        {
            Search = searchModel,
            Sorting = HotelSorting.RatingDesc
        };

        BrowseHotelsInputDto inputDto = new(
            browseModel.Page,
            2,
            searchModel.City,
            searchModel.CheckInDate,
            searchModel.CheckOutDate,
            searchModel.AdultsCount,
            searchModel.RoomsCount,
            browseModel.Sorting,
            browseModel.SelectedFacilityIds);

        BrowseHotelsOutputDto? outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);

        if (outputDto == null)
        {
            ModelState.AddModelError(string.Empty, hotelsService.ErrorMessage);
            return View();
        }

        browseModel.Pager = new(outputDto.TotalPages, 1, Name, nameof(Index));
        browseModel.Hotels = outputDto.SelectedHotels;
        browseModel.Facilities = outputDto.Facilities;
        browseModel.AllHotelsCount = outputDto.AllHotelsCount;

        return View(browseModel);
    }

    [AllowAnonymous]
    [HttpPost]//change this because its not changing db
    public async Task<IActionResult> Index(BrowseHotelsViewModel model, int id)
    {
        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        BrowseHotelsInputDto inputDto = new(
            99,
            2,
            model.Search.City,
            model.Search.CheckInDate,
            model.Search.CheckOutDate,
            model.Search.AdultsCount,
            model.Search.RoomsCount,
            model.Sorting,
            model.SelectedFacilityIds);

        BrowseHotelsOutputDto? outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);

        if (outputDto == null)
        {
            ModelState.AddModelError(string.Empty, hotelsService.ErrorMessage);
            return View(model);
        }

        model.Pager = new(outputDto.TotalPages, model.Page, Name, nameof(Index));
        model.Hotels = outputDto.SelectedHotels;
        model.Facilities = outputDto.Facilities;
        model.AllHotelsCount = outputDto.AllHotelsCount;

        return View(model);
    }
}
