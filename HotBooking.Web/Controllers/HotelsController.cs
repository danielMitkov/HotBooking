using HotBooking.Core.Interfaces;
using HotBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class HotelsController : Controller
{
    private readonly IHotelsService hotelsService;

    public HotelsController(IHotelsService hotelsService)
    {
        this.hotelsService = hotelsService;
    }

    public async Task<IActionResult> List(int page = 1)
    {
        var hotels = await hotelsService.AllHotelsAsync();

        const int pageSize = 1;

        if (page < 1)
        {
            page = 1;
        }

        Pager pager = new Pager(hotels.Count(), page, pageSize);

        int itemsToSkip = (page - 1) * pageSize;

        var pageItems = hotels
            .Skip(itemsToSkip)
            .Take(pager.PageSize)
            .ToArray();

        ViewBag.Pager = pager;

        return View(pageItems);
    }
}
