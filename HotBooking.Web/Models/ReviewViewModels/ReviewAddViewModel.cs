using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Web.Models.ReviewViewModels;

public class ReviewAddViewModel
{
    [Required]
    public Guid HotelPublicId { get; set; }

    [Required]
    [Range(ReviewConstants.RatingScoreMin, ReviewConstants.RatingScoreMax)]
    public decimal RatingScore { get; set; }

    [Required]
    [MinLength(ReviewConstants.TitleLengthMin)]
    [MaxLength(ReviewConstants.TitleLengthMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MinLength(ReviewConstants.CommentMin)]
    [MaxLength(ReviewConstants.CommentMax)]
    public string Comment { get; set; } = null!;
}
