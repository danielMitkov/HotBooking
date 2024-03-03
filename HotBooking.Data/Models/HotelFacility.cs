using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;
public class HotelFacility
{
    [Required]
    public int FacilityId { get; set; }

    [Required, ForeignKey(nameof(FacilityId))]
    public Facility Facility { get; set; } = null!;

    [Required]
    public int HotelId { get; set; }

    [Required, ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;
}
