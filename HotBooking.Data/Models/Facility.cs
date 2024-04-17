using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class Facility : IPublicId
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(FacilityConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(FacilityConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;

    public ICollection<HotelFacility> HotelsFacilities { get; set; } = new HashSet<HotelFacility>();
}
