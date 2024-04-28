using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.RoomDtos;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models.RoomViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class RoomController : BaseController
{
    public const string Name = "Room";

    private readonly ILogger<RoomController> logger;
    private readonly IRoomService roomService;
    private readonly IFeatureService featureService;

    public RoomController(ILogger<RoomController> logger,
        IRoomService roomService,
        IFeatureService featureService)
    {
        this.logger = logger;
        this.roomService = roomService;
        this.featureService = featureService;
    }

    public async Task<IActionResult> Add(Guid hotelId)
    {
        var featureDtos = await featureService.GetFeatureCheckboxesAsync(new List<Guid>());

        var formModel = new RoomFormViewModel()
        {
            HotelPublicId = hotelId,
            Features = featureDtos
        };

        return View(formModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(RoomFormViewModel formModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(formModel);
        }

        var addDto = new RoomAddDto(
            formModel.Title,
            formModel.Description,
            formModel.BedsCount,
            formModel.RoomSizeSquareMeters,
            formModel.PricePerNight,
            formModel.SelectedFeatureIds,
            formModel.ImageUrls);

        try
        {
            await roomService
                .AddAsync(User.GetId(), formModel.HotelPublicId, addDto);

            TempData["OK"] = $"{formModel.Title} Room Added!";

            return RedirectToAction(
                nameof(ManagerController.MyRooms),
                ManagerController.Name,
                new { hotelId = formModel.HotelPublicId });
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

    public async Task<IActionResult> Edit(Guid publicId)
    {
        try
        {
            var roomDto = await roomService
                .GetForEditAsync(User.GetId(), publicId);

            var featureDtos = await featureService
                .GetFeatureCheckboxesAsync(roomDto.SelectedFeatureIds);

            var formModel = new RoomFormViewModel()
            {
                RoomPublicId = publicId,
                Title = roomDto.Title,
                Description = roomDto.Description,
                BedsCount = roomDto.BedsCount,
                RoomSizeSquareMeters = roomDto.RoomSizeSquareMeters,
                PricePerNight = roomDto.PricePerNight,
                ImageUrls = roomDto.ImageUrls,
                Features = featureDtos
            };

            return View(formModel);
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

    [HttpPost]
    public async Task<IActionResult> Edit(RoomFormViewModel formModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(formModel);
        }

        var editDto = new RoomEditDto(
            formModel.RoomPublicId,
            formModel.Title,
            formModel.Description,
            formModel.BedsCount,
            formModel.RoomSizeSquareMeters,
            formModel.PricePerNight,
            formModel.SelectedFeatureIds,
            formModel.ImageUrls);

        try
        {
            var hotelId = await roomService.EditAsync(User.GetId(), editDto);

            TempData["OK"] = $"{formModel.Title} Room is Edited!";

            return RedirectToAction(
                nameof(ManagerController.MyRooms),
                ManagerController.Name,
                new { hotelId = hotelId });
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

    [HttpPost]
    public async Task<IActionResult> Delete(Guid roomId)
    {
        try
        {
            var hotelId = await roomService.DeleteAsync(User.GetId(), roomId);

            TempData["OK"] = "Room Deleted!";

            return RedirectToAction(
                nameof(ManagerController.MyRooms),
                ManagerController.Name,
                new { hotelId = hotelId });
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
