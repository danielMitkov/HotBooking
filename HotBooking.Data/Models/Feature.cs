using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class Feature : IPublicId
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(FeatureConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(FeatureConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;

    public ICollection<RoomFeature> RoomsFeatures { get; set; } = new HashSet<RoomFeature>();
}
