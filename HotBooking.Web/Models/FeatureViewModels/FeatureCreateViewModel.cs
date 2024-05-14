using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.FeatureViewModels;

public class FeatureCreateViewModel
{
    [Required]
    [MinLength(FeatureConstants.NameLengthMin)]
    [MaxLength(FeatureConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(FeatureConstants.SvgTagLengthMin)]
    [MaxLength(FeatureConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;
}
