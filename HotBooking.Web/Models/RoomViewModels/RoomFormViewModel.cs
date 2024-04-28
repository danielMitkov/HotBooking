using HotBooking.Core.Models.DTOs.FeatureDtos;
using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.RoomViewModels;

public class RoomFormViewModel
{
    public Guid RoomPublicId { get; set; }

    public Guid HotelPublicId { get; set; }

    [Required]
    [MinLength(RoomConstants.TitleLengthMin)]
    [MaxLength(RoomConstants.TitleLengthMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MinLength(RoomConstants.DescriptionLengthMin)]
    [MaxLength(RoomConstants.DescriptionLengthMax)]
    public string Description { get; set; } = null!;

    [Required]
    [Range(RoomConstants.BedsCountMin,
        RoomConstants.BedsCountMax)]
    public int BedsCount { get; set; }

    [Required]
    [Range(RoomConstants.RoomSizeSquareMetersMin,
        RoomConstants.RoomSizeSquareMetersMax)]
    public int RoomSizeSquareMeters { get; set; }

    [Required]
    [Range(RoomConstants.PricePerNightMin,
        RoomConstants.PricePerNightMax)]
    public decimal PricePerNight { get; set; }

    public IEnumerable<Guid> SelectedFeatureIds { get; set; } = new List<Guid>();

    [Required]
    public string ImageUrls { get; set; } = null!;


    public IEnumerable<FeatureChecksDto> Features { get; set; } = new List<FeatureChecksDto>();
}
