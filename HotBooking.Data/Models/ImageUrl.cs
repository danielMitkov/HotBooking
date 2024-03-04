using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class ImageUrl
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ImageUrlConstants.UrlLengthMax)]
    public string Url { get; set; } = null!;
}
