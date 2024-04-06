using HotBooking.Core.ErrorMessages;
using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models;

public class SearchHotelsViewModel : IValidatableObject
{
    [Required]
    [MinLength(HotelConstants.CityNameLengthMin)]
    [MaxLength(HotelConstants.CityNameLengthMax)]
    public string City { get; set; } = null!;

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }

    [Required]
    [Range(BookingConstants.AdultsCountMin, BookingConstants.AdultsCountMax)]
    public int AdultsCount { get; set; }

    [Required]
    [Range(BookingConstants.AdultsCountMin, BookingConstants.AdultsCountMax)]
    public int RoomsCount { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CheckInDate < DateTime.Now)
        {
            yield return new ValidationResult(BookingErrors.InThePastCheckIn, new[] { nameof(CheckInDate) });
        }

        if (CheckOutDate < DateTime.Now)
        {
            yield return new ValidationResult(BookingErrors.InThePastCheckOut, new[] { nameof(CheckOutDate) });
        }

        if (CheckInDate > CheckOutDate)
        {
            yield return new ValidationResult(BookingErrors.CheckInDateAfterCheckOutDate, new[] { nameof(CheckInDate) });
        }
    }
}
