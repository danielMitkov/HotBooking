using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Models.DTOs.HotelDtos;
using HotBooking.Core.Models.Enums;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;

public class HotelsServiceTests
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private HotelsService hotelsService;

    private readonly string town = "London";
    private readonly DateTime checkInDate = new DateTime(2024, 6, 17);
    private readonly DateTime checkOutDate = new DateTime(2024, 6, 20);

    public HotelsServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
        .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
        .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();

        seeder = new DataSeeder();

        hotelsService = new HotelsService(dbContext);
    }

    [Fact]
    public async Task GetHotelDetailsAsync_Returns_CorrectRooms()
    {
        var inputDto = new HotelDetailsDtoInput(
            seeder.Hotel_KempinskiHotelGrandArena.PublicId,
            2,
            1,
            checkInDate,
            checkOutDate);

        var outputDto = await hotelsService.GetHotelDetailsAsync(inputDto);

        Assert.Contains(outputDto.Rooms, r => r.PublicId == seeder.Room_KempinskiHotelGrandArena_FamilyGetaway.PublicId);
        Assert.Contains(outputDto.Rooms, r => r.PublicId == seeder.Room_KempinskiHotelGrandArena_MountainLodge.PublicId);
    }

    [Fact]
    public async Task GetHotelDetailsAsync_ThrowsFor_NotFound()
    {
        var inputDto = new HotelDetailsDtoInput(
            Guid.NewGuid(),
            2,
            1,
            checkInDate,
            checkOutDate);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => hotelsService.GetHotelDetailsAsync(inputDto));

        Assert.Equal(HotelErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_Hotel_ChilworthLondonPaddington()
    {
        var selectedFacilitiesGuids = seeder.Facilities
            .Where(f => f.Name == "Spa" || f.Name == "Parking")
            .Select(f => f.PublicId);

        var inputDto = new BrowseHotelsInputDto(
            1,
            2,
            town,
            checkInDate,
            checkOutDate,
            2,
            1,
            HotelSorting.RatingDesc,
            selectedFacilitiesGuids);

        var outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Contains(outputDto.SelectedHotels, h => h.PublicId == seeder.Hotel_ChilworthLondonPaddington.PublicId);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(999)]
    public async Task GetFilteredHotelsAsync_ThrowsFor_OutOfRangePage(int currentPage)
    {
        var inputDto = new BrowseHotelsInputDto(
            currentPage,
            2,
            town,
            checkInDate,
            checkOutDate,
            2,
            1,
            HotelSorting.RatingDesc,
        new List<Guid>());

        await Assert.ThrowsAsync<PageOutOfRangeException>(() => hotelsService.GetFilteredHotelsAsync(inputDto));
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_ThrowsFor_CityNotFound()
    {
        var inputDto = new BrowseHotelsInputDto(
            1,
            1,
            "Fake Town",
            checkInDate,
            checkOutDate,
            2,
            1,
            HotelSorting.RatingDesc,
            new List<Guid>());

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(() => hotelsService.GetFilteredHotelsAsync(inputDto));

        Assert.Equal(HotelErrors.CityNotFound, ex.Message);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_ZeroHotels_For_ZeroAllHotelsCount()
    {
        var inputDto = new BrowseHotelsInputDto(
            1,
            1,
            town,
            checkInDate,
            checkOutDate,
            99,
            1,
            HotelSorting.RatingDesc,
            new List<Guid>());

        var outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Empty(outputDto.SelectedHotels);
        Assert.Equal(0, outputDto.TotalPages);
        Assert.Equal(0, outputDto.AllHotelsCount);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_CorrectOrder_For_PriceDesc()
    {
        var inputDto = new BrowseHotelsInputDto(
            1,
            2,
            town,
            checkInDate,
            checkOutDate,
            2,
            1,
            HotelSorting.PriceDesc,
            new List<Guid>());

        var outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Equal(outputDto.SelectedHotels.First().PublicId, seeder.Hotel_StrandPalace.PublicId);
    }

    [Fact]
    public async Task GetFilteredHotelsAsync_Returns_CorrectOrder_For_PriceAsc()
    {
        var inputDto = new BrowseHotelsInputDto(
            1,
            2,
            town,
            checkInDate,
            checkOutDate,
            2,
            1,
            HotelSorting.PriceAsc,
            new List<Guid>());

        var outputDto = await hotelsService.GetFilteredHotelsAsync(inputDto);

        Assert.Equal(outputDto.SelectedHotels.First().PublicId, seeder.Hotel_ChilworthLondonPaddington.PublicId);
    }

    [Fact]
    public async Task GetMatchingCitiesAsync_Returns_Correct()
    {
        string searchTerm = "lon";

        var cities = await hotelsService.GetMatchingCitiesAsync(searchTerm);

        Assert.Contains("London", cities);
    }

    [Fact]
    public async Task GetMatchingCitiesAsync_NonExistentSearchTerm_ReturnsEmptyCollection()
    {
        string searchTerm = "Fake Town";

        var cities = await hotelsService.GetMatchingCitiesAsync(searchTerm);

        Assert.Empty(cities);
    }
}
