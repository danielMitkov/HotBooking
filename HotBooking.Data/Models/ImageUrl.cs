using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class ImageUrl
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Url { get; set; } = null!;

}
