using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.CartDtos;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;
public class CartServiceTests
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private ICartService cartService;

    private readonly string town = "London";
    private readonly DateTime checkInDate = new DateTime(2024, 6, 17);
    private readonly DateTime checkOutDate = new DateTime(2024, 6, 20);

    public CartServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
        .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
        .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();

        seeder = new DataSeeder();

        cartService = new CartService(dbContext);
    }

    [Fact]
    public async Task AddAsync_CreatesNewCart()
    {
        var inputDto = new CartAddDto(
            seeder.User_Normal.Id,
            seeder.Room_KempinskiHotelGrandArena_FamilyGetaway.PublicId,
            checkInDate,
            checkOutDate,
            2,
            1);

        int cartsCount = await dbContext.Carts.CountAsync();

        await cartService.AddAsync(inputDto);

        var newestCart = await dbContext.Carts
            .OrderBy(c => c.Id)
            .FirstAsync();

        Assert.Equal(cartsCount + 1, await dbContext.Carts.CountAsync());
        Assert.Equal(seeder.User_Normal.Id, newestCart.UserId);
    }
}
