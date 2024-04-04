using HotBooking.Core.DTOs.HotelDtos;
using HotBooking.Core.Enums;
using HotBooking.Core.ErrorMessages;
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

    private readonly DbSet<Hotel> dbSetHotel;
    private readonly DbSet<Facility> dbSetFacility;

    private readonly DbSet<Hotel> dbSetCities;

    private readonly string _town;

    public HotelsServiceTests()
    {
        _dbContext = Substitute.For<HotBookingDbContext>();
        _hotelsService = new HotelsService(_dbContext);
        _seeder = new DataSeeder(true);
        _town = "London";

        dbSetHotel = _seeder.Hotels.BuildMock().BuildMockDbSet();
        dbSetFacility = _seeder.Facilities.BuildMock().BuildMockDbSet();

        dbSetCities = new List<Hotel>()
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
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_Hotel_ChilworthLondonPaddington()
    {
        // Arrange
        _dbContext.Facilities.Returns(dbSetFacility);
        _dbContext.Hotels.Returns(dbSetHotel);

        List<Guid> selectedFacilitiesGuids = _seeder.Facilities
            .Take(2)
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

        // Act
        BrowseHotelsOutputDto? outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        // Assert
        Assert.NotNull(outputDto);
        Assert.Equal(outputDto!.SelectedHotels.First().PublicId, _seeder.Hotel_ChilworthLondonPaddington.PublicId);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_ErrorMessage_For_ZeroTotalPages()
    {
        // Arrange
        _dbContext.Facilities.Returns(dbSetFacility);
        _dbContext.Hotels.Returns(dbSetHotel);

        BrowseHotelsInputDto inputDto = new(
            999,
            1,
            _town,
            new DateTime(2024, 4, 5),
            new DateTime(2024, 4, 11),
            2,
            1,
            HotelSorting.RatingDesc,
            new List<Guid>());

        // Act
        BrowseHotelsOutputDto? outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        // Assert
        Assert.Null(outputDto);
        Assert.Equal(_hotelsService.ErrorMessage, string.Format(HotelErrors.PageNumberOutOfRange, 2));
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_NoHotels()
    {
        // Arrange
        _dbContext.Facilities.Returns(dbSetFacility);
        _dbContext.Hotels.Returns(dbSetHotel);

        BrowseHotelsInputDto inputDto = new(
            1,
            1,
            "Fake Town",
            new DateTime(1, 1, 1),
            new DateTime(9998, 12, 30),
            99999,
            99999,
            HotelSorting.RatingDesc,
            new List<Guid>());

        // Act
        BrowseHotelsOutputDto? outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        // Assert
        Assert.NotNull(outputDto);
        Assert.Empty(outputDto!.SelectedHotels);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_CorrectOrder_For_PriceDesc()
    {
        // Arrange
        _dbContext.Facilities.Returns(dbSetFacility);
        _dbContext.Hotels.Returns(dbSetHotel);

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

        // Act
        BrowseHotelsOutputDto? outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        // Assert
        Assert.NotNull(outputDto);
        Assert.Equal(outputDto!.SelectedHotels.First().PublicId,_seeder.Hotel_StrandPalace.PublicId);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_CorrectOrder_For_PriceAsc()
    {
        // Arrange
        _dbContext.Facilities.Returns(dbSetFacility);
        _dbContext.Hotels.Returns(dbSetHotel);

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

        // Act
        BrowseHotelsOutputDto? outputDto = await _hotelsService.GetFilteredHotelsAsync(inputDto);

        // Assert
        Assert.NotNull(outputDto);
        Assert.Equal(outputDto!.SelectedHotels.First().PublicId, _seeder.Hotel_ChilworthLondonPaddington.PublicId);
    }

    [Fact]
    public async Task GetHotelsCitiesAsync_Returns_CorrectExact()
    {
        // Arrange
        _dbContext.Hotels.Returns(dbSetCities);
        string searchTerm = "New York";

        // Act
        IEnumerable<string> cities = await _hotelsService.GetMatchingCitiesAsync(searchTerm);

        // Assert
        Assert.Single(cities);
        Assert.Equal(searchTerm, cities.First());
    }

    [Fact]
    public async Task GetMatchingCitiesAsync_NonExistentSearchTerm_ReturnsEmptyCollection()
    {
        // Arrange
        _dbContext.Hotels.Returns(dbSetCities);
        string searchTerm = "Fake Town";

        // Act
        IEnumerable<string> cities = await _hotelsService.GetMatchingCitiesAsync(searchTerm);

        // Assert
        Assert.Empty(cities);
    }

    [Fact]
    public async Task GetMatchingCitiesAsync_PartialMatch_ReturnsAllMatchingCities_CaseInsensitive()
    {
        // Arrange
        _dbContext.Hotels.Returns(dbSetCities);
        string searchTerm = "new";

        // Act
        IEnumerable<string> cities = await _hotelsService.GetMatchingCitiesAsync(searchTerm);

        // Assert
        Assert.Equal(2, cities.Count());
        Assert.Contains("New York", cities);
        Assert.Contains("New Orleans", cities);
    }
}
