using System.Security.Claims;

namespace HotBooking.Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetId(this ClaimsPrincipal user)
    {
        string? userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            return -1;
        }

        return int.Parse(userId);
    }
}
