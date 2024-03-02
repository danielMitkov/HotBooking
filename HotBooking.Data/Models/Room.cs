using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class Room
{
    public Room()
    {
        Features = new HashSet<Feature>();
        RoomImages = new HashSet<ImageUrl>();
        Reviews = new HashSet<Review>();

        IsAvailable = true;
    }

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
    public decimal PricePerNight { get; set; }

    [Required]
    public bool IsAvailable { get; set; }

    [Required]
    public int ManagerId { get; set; }

    [ForeignKey(nameof(ManagerId))]
    public Manager Manager { get; set; } = null!;

    [Required]
    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;

    public int? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public Booking? Booking { get; set; }

    public ICollection<Feature> Features { get; set; }

    public ICollection<ImageUrl> RoomImages { get; set; }

    public ICollection<Review> Reviews { get; set; }
}
