using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;
public class Hotel
{
    public Hotel()
    {
        Facilities = new HashSet<Facility>();
        Rooms = new HashSet<Room>();
        HotelImages = new HashSet<ImageUrl>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string StreetAddress { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    public int StarRating { get; set; }

    [Required]
    public int ManagerId { get; set; }

    [ForeignKey(nameof(ManagerId))]
    public Manager Manager { get; set; } = null!;

    public ICollection<Facility> Facilities { get; set; }

    public ICollection<Room> Rooms { get; set; }

    public ICollection<ImageUrl> HotelImages { get; set; }
}
