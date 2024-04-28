using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.UserDtos;
using HotBooking.Data;
using HotBooking.Data.Models;
using HotBooking.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class UserService : IUserService
{
    private readonly HotBookingDbContext dbContext;
    private readonly UserManager<ApplicationUser> userManager;

    public UserService(HotBookingDbContext dbContext,
        UserManager<ApplicationUser> userManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
    }

    public async Task<ICollection<UserRoleDetailsDto>> AllUsersDetailsAsync()
    {
        var users = await dbContext.Users.ToListAsync();

        var usersDtos = users.Select(u => new UserRoleDetailsDto()
        {
            Id = u.Id,
            UserName = u.UserName,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            isAdmin = false
        }).ToList();

        for (int i = 0; i < users.Count; ++i)
        {
            usersDtos[i].isAdmin = await userManager.IsInRoleAsync(users[i], AdminConstants.AdminRoleName);
        }

        return usersDtos;
    }

    public async Task MakeAdminAsync(int userId)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user == null) throw new InvalidModelDataException(UserErrors.NotFound);

        bool isUserAdmin = await userManager.IsInRoleAsync(user, AdminConstants.AdminRoleName);

        if (isUserAdmin == true) throw new InvalidModelDataException(UserErrors.AlreadyAdmin);

        await userManager.AddToRoleAsync(user, AdminConstants.AdminRoleName);
    }

    public async Task MakeNormalAsync(int userId)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user == null) throw new InvalidModelDataException(UserErrors.NotFound);

        bool isUserAdmin = await userManager.IsInRoleAsync(user, AdminConstants.AdminRoleName);

        if (isUserAdmin == false) throw new InvalidModelDataException(UserErrors.AlreadyNormal);

        await userManager.RemoveFromRoleAsync(user, AdminConstants.AdminRoleName);
    }

    public async Task<UserDetailsDto?> GetDetailsAsync(int id)
    {
        var user = await dbContext.Users.Where(u => u.Id == id).Select(u => new UserDetailsDto()
        {
            UserName = u.UserName,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber
        }).SingleOrDefaultAsync();

        return user;
    }

    public async Task EditAsync(int id, UserDetailsDto detailsDto)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

        user.UserName = detailsDto.UserName;
        user.Email = detailsDto.Email;
        user.PhoneNumber = detailsDto.PhoneNumber;

        await dbContext.SaveChangesAsync();
    }
}
