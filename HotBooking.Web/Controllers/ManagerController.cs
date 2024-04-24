using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.ManagerDtos;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models.ManagerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class ManagerController : BaseController
{
    public const string Name = "Manager";

    private readonly IManagerService managerService;
    private readonly ILogger<ManagerController> logger;

    public ManagerController(
        IManagerService managerService,
        ILogger<ManagerController> logger)
    {
        this.managerService = managerService;
        this.logger = logger;
    }

    public async Task<IActionResult> MyHotels()
    {
        try
        {
            var hotelDtos = await managerService.MyHotelsAsync(User.GetId());

            return View(hotelDtos);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());

            TempData["Error"] = ex.Message;

            return RedirectToAction(
                nameof(HomeController.Index),
                HomeController.Name);
        }
    }

    public IActionResult Become()
    {
        var formModel = new ManagerFormViewModel();

        return View(formModel);
    }

    [HttpPost]
    public async Task<IActionResult> Become(ManagerFormViewModel formModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(formModel);
        }

        var formDto = new ManagerFormDto(
            formModel.CompanyName,
            formModel.Department,
            formModel.PhoneNumber);

        try
        {
            await managerService.BecomeAsync(User.GetId(), formDto);

            return RedirectToAction(nameof(MyHotels));
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());

            TempData["Error"] = ex.Message;

            return RedirectToAction(
                nameof(HomeController.Index),
                HomeController.Name);
        }
    }
}
