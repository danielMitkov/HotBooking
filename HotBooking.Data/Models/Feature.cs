using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class Feature : BaseEntity
{
    public Feature()
    {
        RoomsFeatures = new HashSet<RoomFeature>();
    }

    [Required]
    [MaxLength(FeatureConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(FeatureConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;

    public ICollection<RoomFeature> RoomsFeatures { get; set; }
}
