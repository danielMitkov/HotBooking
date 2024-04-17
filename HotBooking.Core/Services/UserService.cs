using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.UserDtos;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class UserService : IUserService
{
    private readonly HotBookingDbContext dbContext;

    public UserService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<UserDetailsDto?> GetDetailsAsync(int id)
    {
        var user = await dbContext.Users
            .Where(u => u.Id == id)
            .Select(u => new UserDetailsDto()
            {
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            })
            .SingleOrDefaultAsync();

        return user;
    }

    public async Task EditAsync(int id, UserDetailsDto detailsDto)
    {
        var user = await dbContext.Users
            .SingleOrDefaultAsync(u => u.Id == id);

        user.UserName = detailsDto.UserName;
        user.Email = detailsDto.Email;
        user.PhoneNumber = detailsDto.PhoneNumber;

        await dbContext.SaveChangesAsync();
    }
}
