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
    [MaxLength(FeatureConstants.IconClassNameLengthMax)]
    public string IconClassName { get; set; } = null!;

    public ICollection<RoomFeature> RoomsFeatures { get; set; }
}
