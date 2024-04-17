using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.HotelDtos;
using HotBooking.Web.Models;
using HotBooking.Web.Models.HotelViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class HotelsController : Controller
{
    public const string Name = "Hotels";

    private readonly ILogger<HotelsController> logger;
    private readonly IHotelsService hotelsService;

    public HotelsController(ILogger<HotelsController> logger,
        IHotelsService hotelsService)
    {
        this.logger = logger;
        this.hotelsService = hotelsService;
    }

    [Route("Hotels/List/{page?}")]
    public async Task<IActionResult> List(BrowseHotelsViewModel browseModel, SearchHotelsViewModel searchModel)
    {
        if (browseModel.SearchModel == null)
        {
            browseModel.SearchModel = searchModel;
        }

        if (ModelState.IsValid == false)
        {
            return View(browseModel);
        }

        var inputDto = new BrowseHotelsInputDto(
            browseModel.Page,
            1,
            browseModel.SearchModel.City,
            browseModel.SearchModel.CheckInDate,
            browseModel.SearchModel.CheckOutDate,
            browseModel.SearchModel.AdultsCount,
            browseModel.SearchModel.RoomsCount,
            browseModel.Sorting,
            browseModel.SelectedFacilityIds);

        try
        {
            var outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);

            browseModel.Pager = new(outputDto.TotalPages, browseModel.Page);
            browseModel.Hotels = outputDto.SelectedHotels;
            browseModel.Facilities = outputDto.Facilities;
            browseModel.AllHotelsCount = outputDto.AllHotelsCount;
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            ModelState.AddModelError(ex.PropertyName, ex.Message);
        }

        return View(browseModel);
    }

    public async Task<IActionResult> Details(Guid id, SearchHotelsViewModel searchModel)
    {
        if (ModelState.IsValid == false)
        {
            return RedirectToAction(nameof(List), searchModel);
        }

        var inputDto = new HotelDetailsDtoInput(
            id,
            searchModel.AdultsCount,
            searchModel.RoomsCount,
            searchModel.CheckInDate,
            searchModel.CheckOutDate);

        try
        {
            var hotelDto = await hotelsService.GetHotelDetailsAsync(inputDto);

            var hotelDetailsModel = new HotelDetailsViewModel()
            {
                HotelId = id,
                Search = searchModel,
                Hotel = hotelDto
            };

            return base.View(hotelDetailsModel);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            return base.RedirectToAction(nameof(List), searchModel);
        }
    }
}
