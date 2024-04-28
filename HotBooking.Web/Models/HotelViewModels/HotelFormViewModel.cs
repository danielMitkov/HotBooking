using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.HotelViewModels;

public class HotelFormViewModel
{
    [Required]
    public Guid PublicId { get; set; }

    [Required]
    [MinLength(HotelConstants.HotelNameLengthMin)]
    [MaxLength(HotelConstants.HotelNameLengthMax)]
    public string HotelName { get; set; } = null!;

    [Required]
    [MinLength(HotelConstants.DescriptionLengthMin)]
    [MaxLength(HotelConstants.DescriptionLengthMax)]
    public string Description { get; set; } = null!;

    [Required]
    [MinLength(HotelConstants.StreetAddressLengthMin)]
    [MaxLength(HotelConstants.StreetAddressLengthMax)]
    public string StreetAddress { get; set; } = null!;

    [Required]
    [MinLength(HotelConstants.CityNameLengthMin)]
    [MaxLength(HotelConstants.CityNameLengthMax)]
    public string CityName { get; set; } = null!;

    [Required]
    [MinLength(HotelConstants.CountryNameLengthMin)]
    [MaxLength(HotelConstants.CountryNameLengthMax)]
    public string CountryName { get; set; } = null!;

    [Required]
    [Range(HotelConstants.StarRatingMin,
        HotelConstants.StarRatingMax)]
    public int StarRating { get; set; }

    public IEnumerable<Guid> SelectedFacilityIds { get; set; } = new List<Guid>();

    [Required]
    public string ImageUrls { get; set; } = null!;


    public IEnumerable<FacilityChecksDto> Facilities { get; set; } = new List<FacilityChecksDto>();
}
