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
        if (ModelState.IsValid == false)
        {
            return View(viewModel);
        }

        var inputDto = new BrowseHotelsInputDto()
        {
            City = viewModel.City,
            CurrentPage = viewModel.Page,
            PageSize = 2,
            Sorting = viewModel.Sorting
        };

        var outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);
        var cities = await hotelsService.GetHotelsCitiesAsync();

        viewModel.CitiesJson = JsonSerializer.Serialize(cities);
        viewModel.Pager = new(outputDto.TotalPages, viewModel.Page, "Hotels", "List", viewModel.City, viewModel.Sorting);
        viewModel.Hotels = outputDto.SelectedHotels
            .Select(h => new PreviewHotelViewModel()
            {
                Id = h.Id,
                ImageUrl = h.ImageUrl,
                HotelName = h.HotelName,
                Description = h.Description,
                FullAddress = h.StreetAddress + ", " + h.CityName,
                StarRating = h.StarRating,
                AverageRating = Math.Round(h.AverageRating, 2)
            });

        return View(viewModel);
    }
}
