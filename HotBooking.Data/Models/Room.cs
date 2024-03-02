using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class Room
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public int BedsCount { get; set; }

    [Required]
    public int RoomSize { get; set; }

    [Required]
    public bool IsAvailable { get; set; }

    [Required]
    public decimal PricePerNight { get; set; }

    public ICollection<Feature> Features { get; set; } = new HashSet<Feature>();

    public ICollection<ImageUrl> RoomImages { get; set; } = new HashSet<ImageUrl>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
