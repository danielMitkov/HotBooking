using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Areas.Admin.Controllers;
public class HomeController : BaseAdminController
{
    public IActionResult Home()
    {
        return View();
    }
}
