using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.FeatureViewModels;

public class FeatureFormViewModel
{
    [Required]
    public Guid PublicId { get; set; }

    [Required]
    [MinLength(FeatureConstants.NameLengthMin)]
    [MaxLength(FeatureConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(FeatureConstants.SvgTagLengthMin)]
    [MaxLength(FeatureConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;
}
