using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.FacilityViewModels;

public class FacilityCreateViewModel
{
    [Required]
    [MinLength(FacilityConstants.NameLengthMin)]
    [MaxLength(FacilityConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(FacilityConstants.SvgTagLengthMin)]
    [MaxLength(FacilityConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;
}
