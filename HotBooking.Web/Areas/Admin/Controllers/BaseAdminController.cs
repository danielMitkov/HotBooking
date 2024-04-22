using HotBooking.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Areas.Admin.Controllers;

[Area(AdminConstants.AdminAreaName)]
[Authorize(Roles = AdminConstants.AdminRoleName)]
public class BaseAdminController : Controller
{
}
