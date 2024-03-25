using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

[Authorize]
public class BaseController : Controller
{
    protected IActionResult InternalServerError(string message)
    {
        return RedirectToAction("Error", "Home", new { statusCode = 500, message = message });
    }

    protected IActionResult RedirectToError<T>(ILogger<T> logger, Exception exception, int statusCode)
    {
        logger.LogError(exception, statusCode.ToString());

        return RedirectToAction("Error", "Home", new { statusCode = statusCode, message = exception.Message });
    }
}
