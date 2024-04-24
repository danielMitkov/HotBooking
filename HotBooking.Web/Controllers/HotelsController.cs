using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.HotelDtos;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models;
using HotBooking.Web.Models.HotelViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class HotelsController : BaseController
{
    public const string Name = "Hotels";

    private readonly ILogger<HotelsController> logger;
    private readonly IHotelsService hotelsService;
    private readonly IFacilityService facilityService;

    public HotelsController(ILogger<HotelsController> logger,
        IHotelsService hotelsService,
        IFacilityService facilityService)
    {
        this.logger = logger;
        this.hotelsService = hotelsService;
        this.facilityService = facilityService;
    }

    [AllowAnonymous]
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

    [AllowAnonymous]
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

    public async Task<IActionResult> Add()
    {
        var facilityDtos = await facilityService.GetFacilityCheckboxesAsync(new List<Guid>());

        var formModel = new HotelFormViewModel()
        {
            Facilities = facilityDtos
        };

        return View(formModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(HotelFormViewModel formModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(formModel);
        }

        var addDto = new HotelAddDto(
            formModel.HotelName,
            formModel.Description,
            formModel.StreetAddress,
            formModel.CityName,
            formModel.CountryName,
            formModel.StarRating,
            formModel.SelectedFacilityIds,
            formModel.ImageUrls);

        try
        {
            await hotelsService.AddAsync(User.GetId(), addDto);

            return RedirectToAction(
                nameof(ManagerController.MyHotels),
                ManagerController.Name);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());

            TempData["Error"] = ex.Message;

            return RedirectToAction(
                nameof(HomeController.Index),
                HomeController.Name);
        }
    }

    public async Task<IActionResult> Edit(Guid publicId)
    {
        try
        {
            var hotelDto = await hotelsService.GetForEditAsync(User.GetId(), publicId);

            var facilities = await facilityService.GetFacilityCheckboxesAsync(hotelDto.SelectedFacilityIds);

            var formModel = new HotelFormViewModel()
            {
                PublicId = publicId,
                HotelName = hotelDto.HotelName,
                Description = hotelDto.Description,
                StreetAddress = hotelDto.StreetAddress,
                CityName = hotelDto.CityName,
                CountryName = hotelDto.CountryName,
                StarRating = hotelDto.StarRating,
                ImageUrls = hotelDto.ImageUrls,
                Facilities = facilities
            };

            return View(formModel);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());

            TempData["Error"] = ex.Message;

            return RedirectToAction(
                nameof(HomeController.Index),
                HomeController.Name);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid publicId, HotelFormViewModel formModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(formModel);
        }

        var editDto = new HotelEditDto(
            publicId,
            formModel.HotelName,
            formModel.Description,
            formModel.StreetAddress,
            formModel.CityName,
            formModel.CountryName,
            formModel.StarRating,
            formModel.SelectedFacilityIds,
            formModel.ImageUrls);

        try
        {
            await hotelsService.EditAsync(User.GetId(), editDto);

            return RedirectToAction(
                nameof(ManagerController.MyHotels),
                ManagerController.Name);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());

            TempData["Error"] = ex.Message;

            return RedirectToAction(
                nameof(HomeController.Index),
                HomeController.Name);
        }
    }
}
