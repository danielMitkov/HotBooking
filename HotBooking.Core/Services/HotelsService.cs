﻿using HotBooking.Core.DTOs.FacilityDtos;
using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Data.Common;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotBooking.Core.Services;

public class HotelsService : IHotelsService
{
    private readonly ILogger<HotelsService> logger;
    private readonly IRepository repository;
    private readonly IPaginationService paginationService;

    public HotelsService(
        ILogger<HotelsService> logger,
        IRepository repository,
        IPaginationService paginationService)
    {
        this.logger = logger;
        this.repository = repository;
        this.paginationService = paginationService;
    }

    public async Task<BrowseHotelsOutputDto> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto, IDictionary<string, string> errors)
    {
        try
        {
            ICollection<Facility> allFacilities = await repository
                .AllReadOnly<Facility>()
                .ToListAsync();


            var selectedFacilities = allFacilities
                .Where(f => inputDto.FacilitySelectedPublicIds.Contains(f.PublicId))
                .ToList();

            var facilityDtos = allFacilities
                .Select(f => new FacilityDto(
                    f.PublicId,
                    selectedFacilities.Contains(f),
                    f.Name,
                    f.SvgTag))
                .ToList();

            var queryHotels = repository
                .AllReadOnly<Hotel>();
            //.Where(h => h.CityName == inputDto.City);

            if (inputDto.FacilitySelectedPublicIds != null && inputDto.FacilitySelectedPublicIds.Any())
            {
                int selectedFacilitiesCount = selectedFacilities.Count;

                ICollection<int> selectedFacilitiesPrimaryKeys = selectedFacilities
                    .Select(f => f.Id)
                    .ToArray();

                queryHotels = queryHotels
                    .Where(hotel => hotel.HotelsFacilities
                    .Count(hf => selectedFacilitiesPrimaryKeys
                    .Contains(hf.FacilityId)) == selectedFacilitiesCount);
            }

            int allHotelsCount = await repository.CountAsync(queryHotels);

            if (allHotelsCount == 0)
            {
                return new BrowseHotelsOutputDto(new List<PreviewHotelDto>(), facilityDtos, 0);
            }

            int totalPages = paginationService.GetTotalPages(allHotelsCount, inputDto.PageSize, inputDto.CurrentPage);

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

            queryHotels = paginationService.ApplyPagination(queryHotels, inputDto.PageSize, inputDto.CurrentPage);

            var selectedHotels = await queryHotels
                .Select(h => new PreviewHotelDto(
                    h.Id,
                    h.HotelImages.First().Url,
                    h.HotelName,
                    h.Description,
                    h.StreetAddress,
                    h.CityName,
                    h.StarRating,
                    h.Reviews.Average(r => (decimal)r.RatingScore),
                    h.Reviews.Count()))
                .ToListAsync();

            var outputDto = new BrowseHotelsOutputDto(selectedHotels, facilityDtos, totalPages);

            return outputDto;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "While trying to get filtered hotels.");

            throw new InternalServerException("get filtered hotels.");
        }
    }

    public async Task<ICollection<string>> GetHotelsCitiesAsync(string searchTerm)
    {
        ICollection<string> cities = await repository
            .AllReadOnly<Hotel>()
            .Where(h => h.CityName.Contains(searchTerm))
            .Select(h => h.CityName)
            .ToListAsync();

        return cities;
    }
}
