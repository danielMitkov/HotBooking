using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.ManagerDtos;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;

public class ManagerServiceTests
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private IManagerService managerService;

    private const string companyName = "Test Company Name";
    private const string department = "Test Department";
    private const string phoneNumber = "088121231234";

    public ManagerServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
                .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();
        seeder = new DataSeeder();

        managerService = new ManagerService(dbContext);
    }

    [Fact]
    public async Task DoesManagerExistAsync_FindsManager()
    {
        bool isFound = await managerService.DoesManagerExistAsync(seeder.User_TobeManager.Id);

        Assert.True(isFound);
    }

    [Fact]
    public async Task DoesManagerExistAsync_DoesNot_FindManager()
    {
        bool isFound = await managerService.DoesManagerExistAsync(seeder.User_Normal.Id);

        Assert.False(isFound);
    }

    [Fact]
    public async Task BecomeAsync_ThrowsFor_UserNotFound()
    {
        var formDto = new ManagerFormDto(
            companyName,
            department,
            phoneNumber);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => managerService.BecomeAsync(-1, formDto));

        Assert.Equal(UserErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task BecomeAsync_CreatesManager()
    {
        var formDto = new ManagerFormDto(
            companyName,
            department,
            phoneNumber);

        await managerService.BecomeAsync(seeder.User_Second.Id, formDto);

        var managerExpected = await dbContext.Managers
            .SingleAsync(m => m.UserId == seeder.User_Second.Id);

        Assert.NotNull(managerExpected);
        Assert.Equal(companyName, managerExpected.CompanyName);
        Assert.Equal(department, managerExpected.Department);
        Assert.Equal(phoneNumber, managerExpected.PhoneNumber);
    }

    [Fact]
    public async Task BecomeAsync_ThrowsFor_AlreadyManager()
    {
        var formDto = new ManagerFormDto(
            companyName,
            department,
            phoneNumber);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => managerService.BecomeAsync(seeder.User_TobeManager.Id, formDto));

        Assert.Equal(ManagerErrors.AlreadyManager, ex.Message);
    }

    [Fact]
    public async Task BecomeAsync_ThrowsFor_ManagerPhoneNumberAlreadyExists()
    {
        var formDto = new ManagerFormDto(
            companyName,
            department,
            seeder.Manager_First.PhoneNumber);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => managerService.BecomeAsync(seeder.User_Second.Id, formDto));

        Assert.Equal(ManagerErrors.PhoneNumberAlreadyExists, ex.Message);
    }

    [Fact]
    public async Task MyHotelsAsync_ThrowsFor_ManagerNotFound()
    {
        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => managerService.MyHotelsAsync(-1));

        Assert.Equal(ManagerErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task MyHotelsAsync_WorksCorrectly()
    {
        var hotelDtos = await managerService.MyHotelsAsync(seeder.User_TobeManager.Id);

        var firstHotel = seeder.Hotel_KempinskiHotelGrandArena;

        Assert.NotNull(hotelDtos);
        Assert.Contains(hotelDtos, h => h.Name == firstHotel.HotelName && h.CityName == firstHotel.CityName);
    }
}
