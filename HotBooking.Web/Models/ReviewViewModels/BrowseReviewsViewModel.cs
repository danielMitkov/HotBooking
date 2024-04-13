using HotBooking.Core.DTOs.ReviewDtos;

namespace HotBooking.Web.Models.ReviewViewModels;

public class BrowseReviewsViewModel
{
    public Guid HotelId { get; set; }
    public int Page { get; set; } = 1;

    
    public int ReviewsCount { get; set; }

    public PagerViewModel? Pager { get; set; }

    public bool CanAddReview { get; set; }

    public IEnumerable<ReviewDetailsDto> Reviews { get; set; } = new List<ReviewDetailsDto>();
}
