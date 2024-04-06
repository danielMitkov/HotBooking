using HotBooking.Core.DTOs.FacilityDtos;
using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class HotelsService : IHotelsService
{
    private readonly HotBookingDbContext dbContext;

    public HotelsService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<BrowseHotelsOutputDto> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto)
    {
        IEnumerable<Facility> allFacilities = await dbContext.Facilities.ToListAsync();

        IEnumerable<Facility> selectedFacilities = allFacilities
            .Where(f => inputDto.FacilitySelectedPublicIds.Contains(f.PublicId));

        IEnumerable<FacilityDto> facilityDtos = allFacilities
            .Select(f => new FacilityDto(
                f.PublicId,
                selectedFacilities.Contains(f),
                f.Name,
                f.SvgTag))
            .ToList();

        IQueryable<Hotel> queryHotels = dbContext.Hotels
            .Where(h => h.CityName == inputDto.City);

        if (inputDto.FacilitySelectedPublicIds.Any())
        {
            int selectedFacilitiesCount = selectedFacilities.Count();

            ICollection<int> selectedFacilitiesPrimaryKeys = selectedFacilities
                .Select(f => f.Id)
                .ToArray();

            queryHotels = queryHotels
                .Where(h => h.HotelsFacilities
                .Count(hf => selectedFacilitiesPrimaryKeys
                .Contains(hf.FacilityId)) == selectedFacilitiesCount);
        }

        int peoplePerRoom = (int)Math.Ceiling(inputDto.AdultsCount / (decimal)inputDto.RoomsCount);

        queryHotels = queryHotels
            .Where(h => h.Rooms
            .Count(r => (r.BedsCount >= peoplePerRoom) && r.Bookings
            .All(b => (inputDto.CheckInDate > b.CheckOut) || (inputDto.CheckOutDate < b.CheckIn))) >= inputDto.RoomsCount);

        int allHotelsCount = await queryHotels.CountAsync();

        if (allHotelsCount == 0)
        {
            return new BrowseHotelsOutputDto(new List<PreviewHotelDto>(), facilityDtos, 0, allHotelsCount);
        }

        int totalPages = (int)Math.Ceiling(allHotelsCount / (decimal)inputDto.PageSize);

        if (inputDto.CurrentPage < 1 || inputDto.CurrentPage > totalPages)
        {
            throw new PageOutOfRangeException(totalPages);
        }

        queryHotels = inputDto.Sorting switch
        {
            HotelSorting.PriceAsc => queryHotels
                .OrderBy(h => h.Rooms.Min(r => r.PricePerNight))
                .ThenBy(h => h.Id),

            HotelSorting.PriceDesc => queryHotels
                .OrderByDescending(h => h.Rooms.Min(r => r.PricePerNight))
                .ThenBy(h => h.Id),

            _ => queryHotels//RatingDesc
                .OrderByDescending(h => h.Reviews.Average(r => r.RatingScore))
                .ThenBy(h => h.Id)
        };

        int skipAmount = (inputDto.CurrentPage - 1) * inputDto.PageSize;

        queryHotels = queryHotels
            .Skip(skipAmount)
            .Take(inputDto.PageSize);

        IEnumerable<PreviewHotelDto> selectedHotels = await queryHotels
            .Select(h => new PreviewHotelDto(
                h.PublicId,
                h.HotelImages.First().Url,
                h.HotelName,
                h.Description,
                h.StreetAddress,
                h.CityName,
                h.StarRating,
                h.Reviews.Average(r => r.RatingScore),
                h.Reviews.Count()))
            .ToListAsync();

        var outputDto = new BrowseHotelsOutputDto(selectedHotels, facilityDtos, totalPages, allHotelsCount);

        return outputDto;
    }

    public async Task<IEnumerable<string>> GetMatchingCitiesAsync(string searchTerm)
    {
        searchTerm = searchTerm.ToLower();

        IEnumerable<string> cities = await dbContext.Hotels
            .Where(h => h.CityName.ToLower().Contains(searchTerm))
            .Select(h => h.CityName)
            .Distinct()
            .ToListAsync();

        return cities;
    }

    public async Task<bool> IsCityFoundAsync(string city)
    {
        city = city.ToLower();

        bool isCityFound = await dbContext.Hotels
            .AnyAsync(h => h.CityName.ToLower() == city);

        return isCityFound;
    }
}
