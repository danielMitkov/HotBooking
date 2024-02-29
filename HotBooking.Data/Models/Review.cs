using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    public int Rating { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Comment { get; set; } = null!;

    [Required]
    public DateTime ReviewedOn { get; set; }

 


}
