using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Components;

public class MainMenuComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult<IViewComponentResult>(View());
    }
}
