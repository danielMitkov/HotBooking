using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class Feature : IPublicId
{
    public Feature()
    {
        PublicId = Guid.NewGuid();
        CreatedOn = DateTime.Now;

        RoomsFeatures = new HashSet<RoomFeature>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(FeatureConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    [MaxLength(FeatureConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;

    public virtual ICollection<RoomFeature> RoomsFeatures { get; set; }
}
