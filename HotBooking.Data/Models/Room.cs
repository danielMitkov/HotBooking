using HotBooking.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class Room
{
    [Key]
    public int Id { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string Title { get; set; } = null!;

    public ICollection<Feature> Features { get; set; } = new HashSet<Feature>();

    public RoomType RoomType { get; set; }
    public bool IsAvailable { get; set; }
    public int MaximumGuests { get; set; }
    public ICollection<ImageUrl> RoomImages { get; set; } = new HashSet<ImageUrl>();
    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
