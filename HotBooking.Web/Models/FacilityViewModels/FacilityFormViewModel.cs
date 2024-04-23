using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.FacilityViewModels;

public class FacilityFormViewModel
{
    [Required]
    public Guid PublicId { get; set; }

    [Required]
    [MinLength(FacilityConstants.NameLengthMin)]
    [MaxLength(FacilityConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(FacilityConstants.SvgTagLengthMin)]
    [MaxLength(FacilityConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;
}
