using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class Facility : BaseEntity
{
    [Required]
    [MaxLength(FacilityConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(FacilityConstants.SvgTagLengthMax)]
    public string SvgTag { get; set; } = null!;

    public ICollection<HotelFacility> HotelsFacilities { get; set; } = new HashSet<HotelFacility>();
}
