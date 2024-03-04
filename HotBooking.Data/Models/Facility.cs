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
    public string Name { get; set; } = null!;

    [Required]
    public string IconClassName { get; set; } = null!;

    public ICollection<HotelFacility> HotelsFacilities { get; set; }
}
