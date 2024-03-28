using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Interfaces.ValidationInterfaces;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models;
using HotBooking.Web.Models.HotelViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    public async Task<IActionResult> Index(string city, DateTime checkInDate, DateTime checkOutDate, int adultsCount, int roomsCount)
    {
        try
        {
            BrowseHotelsInputDto inputDto = new(
                1,
                2,
                city,
                checkInDate,
                checkOutDate,
                adultsCount,
                roomsCount,
                HotelSorting.RatingDesc,
                new List<Guid>());

            Dictionary<string, string> modelErrors = new();

            BrowseHotelsOutputDto outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto, modelErrors);

            if (!ModelState.IsValidAfterAddingErrors(modelErrors))
            {
                return View();
            }

            BrowseHotelsViewModel viewModel = new()
            {
                Sorting = HotelSorting.RatingDesc,
                Search = new SearchHotelsViewModel()
                {
                    City = city,
                    CheckInDate = checkInDate,
                    CheckOutDate = checkOutDate,
                    AdultsCount = adultsCount,
                    RoomsCount = roomsCount
                },
                Pager = new(outputDto.TotalPages, 1, Name, nameof(Index)),
                Hotels = outputDto.SelectedHotels,
                Facilities = outputDto.Facilities
            };

            return View(viewModel);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Index(BrowseHotelsViewModel model)
    {
        try
        {
            BrowseHotelsInputDto inputDto = new(
                model.Page,
                2,
                model.Search.City,
                model.Search.CheckInDate,
                model.Search.CheckOutDate,
                model.Search.AdultsCount,
                model.Search.RoomsCount,
                model.Sorting,
                model.SelectedFacilityIds);

            Dictionary<string, string> modelErrors = new();

            BrowseHotelsOutputDto outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto, modelErrors);

            if (!ModelState.IsValidAfterAddingErrors(modelErrors))
            {
                return View(model);
            }

            model.Pager = new(outputDto.TotalPages, model.Page, "Hotels", "Index");
            model.Hotels = outputDto.SelectedHotels;
            model.Facilities = outputDto.Facilities;

            return View(model);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
