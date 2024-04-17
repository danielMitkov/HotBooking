using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.UserDtos;
using HotBooking.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Details()
        {
            var user = await userService.GetDetailsAsync(User.GetId());

            return View(user);
        }

        public async Task<IActionResult> Edit()
        {
            var user = await userService.GetDetailsAsync(User.GetId());

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDetailsDto applicationUser)
        {
            if (ModelState.IsValid == false)
            {
                return View(applicationUser);
            }

            try
            {
                await userService.EditAsync(User.GetId(), applicationUser);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(applicationUser);
            }
        }
    }
}
