using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Interfaces.ValidationInterfaces;
using HotBooking.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotBooking.Web.Extensions;

public static class ModelStateExtensions
{
    public static async Task AddModelErrorsForSearchHotelsViewModel(this ModelStateDictionary modelState, 
        SearchHotelsViewModel viewModel, 
        IHotelValidationService hotelValidationService, 
        IBookingValidationService bookingValidationService)
    {
        if ((await hotelValidationService.IsCityFoundAsync(viewModel.City)) == false)
        {
            modelState.AddModelError(nameof(viewModel.City), HotelErrors.CityNotFound);
        }

        if (bookingValidationService.IsDateNotInThePast(viewModel.CheckInDate) == false)
        {
            modelState.AddModelError(nameof(viewModel.CheckInDate), BookingErrors.CheckInDateInThePast);
        }

        if (bookingValidationService.IsDateNotInThePast(viewModel.CheckOutDate) == false)
        {
            modelState.AddModelError(nameof(viewModel.CheckOutDate), BookingErrors.CheckOutDateInThePast);
        }

        if (bookingValidationService.IsCheckOutAfterCheckIn(viewModel.CheckInDate, viewModel.CheckOutDate) == false)
        {
            modelState.AddModelError(nameof(viewModel.CheckOutDate), BookingErrors.CheckInDateAfterCheckOutDate);
        }
    }

    public static bool IsValidAfterAddingErrors(this ModelStateDictionary modelState, IDictionary<string, string> modelErrors)
    {
        foreach ((string key, string errorMessage) in modelErrors)
        {
            modelState.AddModelError(key, errorMessage);
        }

        return modelState.IsValid;
    }
}
