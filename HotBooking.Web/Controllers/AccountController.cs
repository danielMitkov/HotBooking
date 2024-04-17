using HotBooking.Data.Models;
using HotBooking.Web.Models.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class AccountController : Controller
{
    public const string Name = "Account";

    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IUserStore<ApplicationUser> userStore;
    private readonly UserManager<ApplicationUser> userManager;

    public AccountController(
        SignInManager<ApplicationUser> signInManager,
        IUserStore<ApplicationUser> userStore,
        UserManager<ApplicationUser> userManager)
    {
        this.signInManager = signInManager;
        this.userStore = userStore;
        this.userManager = userManager;
    }

    public async Task<IActionResult> Login()
    {
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(loginModel);
        }

        var result = await signInManager
                .PasswordSignInAsync(loginModel.Email, loginModel.Password, true, false);

        if (result.Succeeded)
        {
            return RedirectToAction(nameof(HomeController.Index), HomeController.Name);
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(loginModel);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(registerModel);
        }

        var user = CreateUser();

        await userStore.SetUserNameAsync(user, registerModel.Email, CancellationToken.None);

        var result = await userManager.CreateAsync(user, registerModel.Password);

        if (result.Succeeded == false)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerModel);
        }

        await signInManager.SignInAsync(user, isPersistent: false);
        return RedirectToAction(nameof(HomeController.Index), HomeController.Name);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction(nameof(HomeController.Index), HomeController.Name);
    }

    private ApplicationUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<ApplicationUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }
}
