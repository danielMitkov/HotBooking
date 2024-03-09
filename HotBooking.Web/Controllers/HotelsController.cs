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
}
