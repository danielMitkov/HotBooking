using HotBooking.Data.Constants;
using HotBooking.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models;

public class SearchHotelsViewModel
{
    [Required]
    [MinLength(HotelConstants.CityNameLengthMin)]
    [MaxLength(HotelConstants.CityNameLengthMax)]
    [Remote(nameof(ValidationController.CityExists), ValidationController.Name)]
    public string City { get; set; } = null!;

    [Required]
    [Remote(nameof(ValidationController.AreDatesValid), ValidationController.Name, AdditionalFields = nameof(CheckOutDate))]
    public DateTime CheckInDate { get; set; }

    [Required]
    [Remote(nameof(ValidationController.AreDatesValid), ValidationController.Name, AdditionalFields = nameof(CheckInDate))]
    public DateTime CheckOutDate { get; set; }

    [Required]
    [Range(BookingConstants.AdultsCountMin, BookingConstants.AdultsCountMax)]
    public int AdultsCount { get; set; }

    [Required]
    [Range(BookingConstants.AdultsCountMin, BookingConstants.AdultsCountMax)]
    public int RoomsCount { get; set; }
}
