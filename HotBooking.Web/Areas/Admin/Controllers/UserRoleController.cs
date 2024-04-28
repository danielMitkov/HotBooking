using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Areas.Admin.Controllers;

public class UserRoleController : BaseAdminController
{
    public const string Name = "UserRole";

    private readonly IUserService userService;
    private readonly ILogger<UserRoleController> logger;

    public UserRoleController(IUserService userService,
        ILogger<UserRoleController> logger)
    {
        this.userService = userService;
        this.logger = logger;
    }

    public async Task<IActionResult> Manage()
    {
        var usersDtos = await userService.AllUsersDetailsAsync();

        return View(usersDtos);
    }

    public async Task<IActionResult> MakeAdmin(int userId)
    {
        try
        {
            await userService.MakeAdminAsync(userId);

            TempData["OK"] = $"User with Id: {userId} is now Admin!";

            return RedirectToAction(nameof(Manage));
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());

            TempData["Error"] = ex.Message;

            return RedirectToAction(nameof(Manage));
        }
    }

    public async Task<IActionResult> MakeNormal(int userId)
    {
        try
        {
            await userService.MakeNormalAsync(userId);

            TempData["OK"] = $"User with Id: {userId} is now a Normal user!";

            return RedirectToAction(nameof(Manage));
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());

            TempData["Error"] = ex.Message;

            return RedirectToAction(nameof(Manage));
        }
    }
}
