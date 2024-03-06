using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class Feature
{
    public Feature()
    {
        RoomsFeatures = new HashSet<RoomFeature>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(FeatureConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(FeatureConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;

    public ICollection<RoomFeature> RoomsFeatures { get; set; }
}
