using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Services;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace HotBooking.Core.Tests;

public class HotelsServiceTests
{
    private readonly HotBookingDbContext _dbContext;
    private readonly HotelsService _hotelsService;
    private readonly DataSeeder _seeder;

    private readonly string _town;

    public HotelsServiceTests()
    {
        _dbContext = Substitute.For<HotBookingDbContext>();
        _hotelsService = new HotelsService(_dbContext);
        _seeder = new DataSeeder(true);
        _town = "London";

        DbSet<Hotel> dbSetHotel = _seeder.Hotels.BuildMock().BuildMockDbSet();
        _dbContext.Hotels.Returns(dbSetHotel);

        DbSet<Facility> dbSetFacility = _seeder.Facilities.BuildMock().BuildMockDbSet();
        _dbContext.Facilities.Returns(dbSetFacility);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_Hotel_ChilworthLondonPaddington()
    {
        ICollection<Guid> selectedFacilitiesGuids = _seeder.Facilities
            .Where(f => f.Name == "Spa" || f.Name == "Parking")
            .Select(f => f.PublicId)
            .ToList();

        BrowseHotelsInputDto inputDto = new(
            1,
            2,
            _town,
            new DateTime(2024, 4, 5),
            new DateTime(2024, 4, 11),
            2,
            1,
            HotelSorting.RatingDesc,
            selectedFacilitiesGuids);

        BrowseHotelsOutputDto outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Single(outputDto.SelectedHotels);
        Assert.Equal(outputDto.SelectedHotels.First().PublicId, _seeder.Hotel_ChilworthLondonPaddington.PublicId);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(999)]
    public async Task GetFilteredHotelsAsync_WorksNormallyDespite_OutOfRangePage(int currentPage)
    {
        BrowseHotelsInputDto inputDto = new(
            currentPage,
            2,
            _town,
            new DateTime(2024, 4, 5),
            new DateTime(2024, 4, 11),
            2,
            1,
            HotelSorting.RatingDesc,
            new List<Guid>());

        BrowseHotelsOutputDto outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Equal(2, outputDto.SelectedHotels.Count());
        Assert.Contains(outputDto.SelectedHotels, h => h.PublicId == _seeder.Hotel_ChilworthLondonPaddington.PublicId);
        Assert.Contains(outputDto.SelectedHotels, h => h.PublicId == _seeder.Hotel_StrandPalace.PublicId);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_ThrowsFor_CityNotFound()
    {
        BrowseHotelsInputDto inputDto = new(
            1,
            1,
            "Fake Town",
            new DateTime(2024, 4, 5),
            new DateTime(2024, 4, 11),
            2,
            1,
            HotelSorting.RatingDesc,
            new List<Guid>());

        await Assert.ThrowsAsync<CityNotFound>(() => _hotelsService.GetFilteredHotelsAsync(inputDto));
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_ZeroHotels_For_ZeroAllHotelsCount()
    {
        BrowseHotelsInputDto inputDto = new(
            1,
            1,
            _town,
            new DateTime(1, 4, 5),
            new DateTime(9998, 4, 11),
            2,
            1,
            HotelSorting.RatingDesc,
            new List<Guid>());

        BrowseHotelsOutputDto outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Empty(outputDto.SelectedHotels);
        Assert.Equal(0, outputDto.TotalPages);
        Assert.Equal(0, outputDto.AllHotelsCount);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_CorrectOrder_For_PriceDesc()
    {
        BrowseHotelsInputDto inputDto = new(
            1,
            2,
            _town,
            new DateTime(2024, 4, 5),
            new DateTime(2024, 4, 11),
            2,
            1,
            HotelSorting.PriceDesc,
            new List<Guid>());

        BrowseHotelsOutputDto outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Equal(outputDto.SelectedHotels.First().PublicId, _seeder.Hotel_StrandPalace.PublicId);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_CorrectOrder_For_PriceAsc()
    {
        BrowseHotelsInputDto inputDto = new(
            1,
            2,
            _town,
            new DateTime(2024, 4, 5),
            new DateTime(2024, 4, 11),
            2,
            1,
            HotelSorting.PriceAsc,
            new List<Guid>());

        BrowseHotelsOutputDto outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Equal(outputDto.SelectedHotels.First().PublicId, _seeder.Hotel_ChilworthLondonPaddington.PublicId);
    }

    [Fact]
    public async Task GetMatchingCitiesAsync_Returns_CorrectExact()
    {
        DbSet<Hotel> dbSetCities = new List<Hotel>()
        {
            new Hotel { CityName = "New York" },
            new Hotel { CityName = "Los Angeles" },
            new Hotel { CityName = "New Orleans" },
            new Hotel { CityName = "Chicago" },
            new Hotel { CityName = "Houston" },
            new Hotel { CityName = "Phoenix" },
            new Hotel { CityName = "Philadelphia" },
            new Hotel { CityName = "San Antonio" },
            new Hotel { CityName = "San Diego" },
            new Hotel { CityName = "Dallas" },
            new Hotel { CityName = "San Jose" }
        }
        .BuildMock().BuildMockDbSet();
        _dbContext.Hotels.Returns(dbSetCities);

        string searchTerm = "New";

        ICollection<string> cities = await _hotelsService.GetMatchingCitiesAsync(searchTerm);

        Assert.Equal(2, cities.Count);
        Assert.Contains("New York", cities);
        Assert.Contains("New Orleans", cities);
    }

    [Fact]
    public async Task GetMatchingCitiesAsync_NonExistentSearchTerm_ReturnsEmptyCollection()
    {
        string searchTerm = "Fake Town";

        ICollection<string> cities = await _hotelsService.GetMatchingCitiesAsync(searchTerm);

        Assert.Empty(cities);
    }
}
