using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.BookingDtos;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;
public class BookingServiceTests
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private IBookingService bookingService;

    private readonly string town = "London";
    private readonly DateTime checkInDate = new DateTime(2024, 6, 17);
    private readonly DateTime checkOutDate = new DateTime(2024, 6, 20);

    public BookingServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
        .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
        .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();

        seeder = new DataSeeder();

        bookingService = new BookingService(dbContext);
    }

    [Fact]
    public async Task AddAsync_AddsBooking_Correctly()
    {
        var inputDto = new BookingAddDto(
            seeder.User_Normal.Id,
            seeder.Room_KempinskiHotelGrandArena_FamilyGetaway.PublicId,
            checkInDate,
            checkOutDate,
            2);

        int bookingsCount = await dbContext.Bookings.CountAsync();

        await bookingService.AddAsync(inputDto);

        var newestBooking = await dbContext.Bookings
            .OrderBy(c => c.Id)
            .FirstAsync();

        Assert.Equal(bookingsCount + 1, await dbContext.Bookings.CountAsync());
        Assert.Equal(seeder.User_Normal.Id, newestBooking.UserId);
    }
}
