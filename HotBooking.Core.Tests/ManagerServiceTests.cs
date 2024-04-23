using HotBooking.Core.Interfaces;
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
}
