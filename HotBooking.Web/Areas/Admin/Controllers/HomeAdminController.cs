using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Areas.Admin.Controllers;

public class HomeAdminController : BaseAdminController
{
    public const string Name = "HomeAdmin";

    public IActionResult Index()
    {
        return View();
    }
}
