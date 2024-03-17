using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
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

        if (string.IsNullOrWhiteSpace(inputDto.City) == false)
        {
            queryHotels = queryHotels.Where(h => h.CityName == inputDto.City);
        }

        int allHotelsCount = await queryHotels.CountAsync();

        queryHotels = queryHotels
            .Skip((inputDto.CurrentPage - 1) * inputDto.PageSize)
            .Take(inputDto.PageSize);

        queryHotels = inputDto.Sorting switch
        {
            HotelSorting.PriceAsc => queryHotels.OrderBy(h => h.Rooms.Min(r => r.PricePerNight)),

            HotelSorting.PriceDesc => queryHotels.OrderByDescending(h => h.Rooms.Min(r => r.PricePerNight)),

            _ => queryHotels.OrderByDescending(h => h.Reviews.Average(r => r.RatingScore))//HotelSorting.RatingDesc
        };

        PreviewHotelDto[] selectedHotels = await queryHotels
                .Select(h => new PreviewHotelDto
                {
                    Id = h.Id,
                    ImageUrl = h.HotelImages.First().Url,
                    HotelName = h.HotelName,
                    Description = h.Description,
                    StreetAddress = h.StreetAddress,
                    CityName = h.CityName,
                    //FullAddress = h.StreetAddress + ", " + h.CityName,
                    StarRating = h.StarRating,
                    //AverageRating = Math.Round(h.Reviews.Average(r => r.RatingScore), 2),
                    AverageRating = h.Reviews.Average(r => (decimal)r.RatingScore),
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

    public async Task<ICollection<string>> GetHotelsCitiesAsync()
    {
        string[] cities = await repository.AllReadOnly<Hotel>()
            .Select(h => h.CityName)
            .ToArrayAsync();

        return cities;
    }
}
