using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;
public class ManagerController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Become()
    {
        return View();
    }
}
