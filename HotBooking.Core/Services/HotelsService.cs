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

    public async Task<ICollection<AllHotelDto>> AllHotelsAsync()
    {
        var hotels = await repository
            .AllReadOnly<Hotel>()
            .Select(h => new AllHotelDto
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

        return hotels;
    }
}
