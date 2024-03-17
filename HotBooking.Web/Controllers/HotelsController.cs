using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Interfaces;
using HotBooking.Web.Models.HotelViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HotBooking.Web.Controllers;

public class HotelsController : Controller
{
    private readonly IHotelsService hotelsService;

    public HotelsController(IHotelsService hotelsService)
    {
        this.hotelsService = hotelsService;
    }

    public async Task<IActionResult> List(BrowseHotelsViewModel viewModel)
    {
        var inputDto = new BrowseHotelsInputDto()
        {
            City = viewModel.City,
            CurrentPage = viewModel.Page,
            PageSize = 1
        };

        var outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);
        var cities = await hotelsService.GetHotelsCitiesAsync();

        viewModel.CitiesJson = JsonSerializer.Serialize(cities);
        viewModel.Hotels = outputDto.SelectedHotels;
        viewModel.Pager = new(outputDto.TotalPages, viewModel.Page, "Hotels", "List", viewModel.City);

        return View(viewModel);
    }
}
