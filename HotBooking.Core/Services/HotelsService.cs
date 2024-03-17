using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Interfaces;
using HotBooking.Data.Common;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;
public class HotelsService : IHotelsService
{
    private readonly IRepository repository;

    public HotelsService(IRepository repository)
    {
        this.repository = repository;
    }

    public async Task<BrowseHotelsOutputDto> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto)
    {
        var queryHotels = repository.AllReadOnly<Hotel>();

        if (!string.IsNullOrWhiteSpace(inputDto.City))
        {
            queryHotels = queryHotels.Where(h => h.CityName == inputDto.City);
        }

        int allHotelsCount = await queryHotels.CountAsync();

        PreviewHotelDto[] selectedHotels = await queryHotels
            .Skip((inputDto.CurrentPage - 1) * inputDto.PageSize)
            .Take(inputDto.PageSize)
            .Select(h => new PreviewHotelDto
            {
                Id = h.Id,
                ImageUrl = h.HotelImages.First().Url,
                HotelName = h.HotelName,
                Description = h.Description,
                FullAddress = h.StreetAddress + ", " + h.CityName,
                StarRating = h.StarRating,
                AverageRating = Math.Round(h.Reviews.Average(r => r.RatingScore), 2),
                ReviewsCount = h.Reviews.Count()
            })
            .ToArrayAsync();

        int totalPages = (int)Math.Ceiling(allHotelsCount / (decimal)inputDto.PageSize);

        var outputDto = new BrowseHotelsOutputDto()
        {
            SelectedHotels = selectedHotels,
            TotalPages = totalPages
        };

        return outputDto;
    }
    }
}
