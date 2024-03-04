using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class Facility
{
    public Facility()
    {
        HotelsFacilities = new HashSet<HotelFacility>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(FacilityConstants.NameLengthMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(FacilityConstants.IconClassNameLengthMax)]
    public string IconClassName { get; set; } = null!;

    public ICollection<HotelFacility> HotelsFacilities { get; set; }
}
