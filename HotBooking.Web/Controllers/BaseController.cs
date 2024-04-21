using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

[Authorize]
public class BaseController : Controller
{
}
