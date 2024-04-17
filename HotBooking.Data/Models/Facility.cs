using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class Facility : IPublicId
{
    public Facility()
    {
        PublicId = Guid.NewGuid();
        IsActive = true;
        CreatedOn = DateTime.Now;

        HotelsFacilities = new HashSet<HotelFacility>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    [MaxLength(FacilityConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    [MaxLength(FacilityConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;

    public virtual ICollection<HotelFacility> HotelsFacilities { get; set; }
}
