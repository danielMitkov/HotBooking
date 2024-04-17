using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.CartDtos;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class CartController : Controller
{
    public const string Name = "Cart";

    private readonly ILogger<CartController> logger;
    private readonly ICartService cartService;

    public CartController(
        ILogger<CartController> logger,
        ICartService cartService)
    {
        this.logger = logger;
        this.cartService = cartService;
    }

    [Route("Cart/Add/{roomId}")]
    public async Task<IActionResult> Add(Guid roomId, SearchHotelsViewModel search)
    {
        var addDto = new CartAddDto(
            User.GetId(),
            roomId,
            search.CheckInDate,
            search.CheckOutDate,
            search.AdultsCount,
            search.RoomsCount);

        try
        {
            var cartPublicId = await cartService.AddAsync(addDto);

            return RedirectToAction(nameof(Manage), new { cartPublicId });
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            TempData["Error"] = ex.Message;
            return RedirectToAction(nameof(HotelsController.List), HotelsController.Name);
        }
    }

    public async Task<IActionResult> Remove(Guid cartPublicId)
    {
        return View();
    }
}
