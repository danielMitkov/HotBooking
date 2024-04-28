using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.RoomDtos;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;

public class RoomServiceTests
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private IRoomService roomService;

    public RoomServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
                .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();
        seeder = new DataSeeder();

        roomService = new RoomService(dbContext);
    }

    [Fact]
    public async Task GetForEditAsync_Works()
    {
        var resultDto = await roomService
            .GetForEditAsync(seeder.User_TobeManager.Id, seeder.Room_KempinskiHotelGrandArena_MountainLodge.PublicId);

        Assert.NotNull(resultDto);
    }

    [Fact]
    public async Task EditAsync_Works_As_Expected()
    {
        var newTitle = "NEW";
        var newDesc = "NEW";
        var newBedsCound = 9;
        var newSize = 7;
        var newPricePerNight = 8;

        var editDto = new RoomEditDto(
            seeder.Room_KempinskiHotelGrandArena_MountainLodge.PublicId,
            newTitle,
            newDesc,
            newBedsCound,
            newSize,
            newPricePerNight,
            new List<Guid>(),
            string.Empty);

        var hotelGuid = await roomService
            .EditAsync(seeder.User_TobeManager.Id, editDto);

        Assert.Equal(seeder.Hotel_KempinskiHotelGrandArena.PublicId, hotelGuid);
    }

    [Fact]
    public async Task AddAsync_WorksCorrectly()
    {
        var addDto = new RoomAddDto(
            "Title",
            "Desciption",
            4,
            4,
            4,
            new List<Guid>(),
            string.Empty);

        await roomService
            .AddAsync(seeder.User_TobeManager.Id,
            seeder.Hotel_StrandPalace.PublicId,
            addDto);

        bool exists = await dbContext.Rooms
            .AnyAsync(r => r.Title == "Title");

        Assert.True(exists);
    }

    [Fact]
    public async Task DeleteAsync_WorksCorrectly()
    {
        var hotelGuid = await roomService
            .DeleteAsync(seeder.User_TobeManager.Id, seeder.Room_ChilworthLondonPaddington_CozyRetreat.PublicId);

        Assert.Equal(seeder.Hotel_ChilworthLondonPaddington.PublicId, hotelGuid);
    }
}
