using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotBooking.Web.Extensions;

public static class ModelStateExtensions
{
    public static bool IsValidAfterAddingErrors(this ModelStateDictionary modelState, IDictionary<string, string> modelErrors)
    {
        foreach ((string key, string errorMessage) in modelErrors)
        {
            modelState.AddModelError(key, errorMessage);
        }

        return modelState.IsValid;
    }
}
