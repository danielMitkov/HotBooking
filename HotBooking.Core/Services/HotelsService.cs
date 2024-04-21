using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Core.Models.DTOs.HotelDtos;
using HotBooking.Core.Models.DTOs.RoomDtos;
using HotBooking.Core.Models.Enums;
using HotBooking.Data;
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
        if ((await IsCityFoundAsync(inputDto.City)) == false)
        {
            throw new InvalidModelDataException(nameof(inputDto.City), HotelErrors.CityNotFound);
        }

        var allFacilities = await dbContext.Facilities.ToListAsync();

        var selectedFacilities = allFacilities
            .Where(f => inputDto.FacilitySelectedPublicIds.Contains(f.PublicId));

        var facilityDtos = allFacilities
            .Select(f => new FacilityChecksDto(
                f.PublicId,
                selectedFacilities.Contains(f),
                f.Name,
                f.SvgTag));

        var queryHotels = dbContext.Hotels
            .Where(h => h.CityName == inputDto.City);

        if (inputDto.FacilitySelectedPublicIds.Any())
        {
            int selectedFacilitiesCount = selectedFacilities.Count();

            var selectedFacilitiesPrimaryKeys = selectedFacilities
                .Select(f => f.Id);

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
            return new BrowseHotelsOutputDto(new List<HotelPreviewDto>(), facilityDtos, 0, allHotelsCount);
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

        var selectedHotels = await queryHotels
            .Select(h => new HotelPreviewDto(
                h.PublicId,
                h.HotelImages.First().Url,
                h.HotelName,
                h.Description,
                h.StreetAddress,
                h.CityName,
                h.StarRating,
                h.Reviews.Sum(r => r.RatingScore) / (h.Reviews.Count() == 0 ? 1 : h.Reviews.Count()),
                h.Reviews.Count()))
            .ToListAsync();

        var outputDto = new BrowseHotelsOutputDto(selectedHotels, facilityDtos, totalPages, allHotelsCount);

        return outputDto;
    }

    public async Task<IEnumerable<string>> GetMatchingCitiesAsync(string searchTerm)
    {
        searchTerm = searchTerm.ToLower();

        var cities = await dbContext.Hotels
            .Where(h => h.CityName.ToLower().Contains(searchTerm))
            .Select(h => h.CityName)
            .Distinct()
            .ToListAsync();

        return cities;
    }

    public async Task<HotelDetailsDtoOutput> GetHotelDetailsAsync(HotelDetailsDtoInput inputDto)
    {
        int peoplePerRoom = (int)Math.Ceiling(inputDto.AdultsCount / (decimal)inputDto.RoomsCount);

        var hotelDto = await dbContext.Hotels
            .Where(h => h.PublicId == inputDto.PublicId)
            .Select(h => new HotelDetailsDtoOutput(
                h.HotelName,
                h.Description,
                h.StreetAddress,
                h.CityName,
                h.CountryName,
                h.StarRating,
                h.Reviews.Sum(r => r.RatingScore) / (h.Reviews.Count() == 0 ? 1 : h.Reviews.Count()),
                h.Reviews.Count(),
                h.HotelsFacilities
                    .Select(hf => new FacilityDetailsDto(
                        hf.Facility.Name,
                        hf.Facility.SvgTag
                    )),
                h.HotelImages.Select(i => i.Url),
                h.Rooms
                    .Where(r => (r.BedsCount >= peoplePerRoom) && r.Bookings
                        .All(b => (inputDto.CheckInDate > b.CheckOut) || (inputDto.CheckOutDate < b.CheckIn)))
                    .Select(r => new RoomDetailsDto(
                        r.PublicId,
                        r.Title,
                        r.Description,
                        r.BedsCount,
                        r.RoomSizeSquareMeters,
                        r.PricePerNight,
                        r.RoomsFeatures.Select(rf => rf.Feature.Name),
                        r.RoomImages.Select(i => i.Url)
                    ))
            ))
            .SingleOrDefaultAsync();

        if (hotelDto == null)
        {
            throw new InvalidModelDataException(HotelErrors.NotFound);
        }

        return hotelDto;
    }

    public async Task<bool> IsCityFoundAsync(string city)
    {
        city = city.ToLower();

        bool isCityFound = await dbContext.Hotels
            .AnyAsync(h => h.CityName.ToLower() == city);

        return isCityFound;
    }
}
