using HotBooking.Core.Interfaces;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class ManagerService : IManagerService
{
    private readonly HotBookingDbContext dbContext;

    public ManagerService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DoesManagerExistAsync(int userId)
    {
        bool isManagerFound = await dbContext.Managers
            .AnyAsync(m => m.UserId == userId);

        return isManagerFound;
    }
}
