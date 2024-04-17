using HotBooking.Core.Models.DTOs.ReviewDtos;

namespace HotBooking.Web.Models.ReviewViewModels;

public class ReviewBrowseViewModel
{
    public Guid HotelPublicId { get; set; }
    public int Page { get; set; } = 1;


    public int ReviewsCount { get; set; }

    public PagerViewModel? Pager { get; set; }

    public bool CanAddReview { get; set; }

    public IEnumerable<ReviewDetailsDto> Reviews { get; set; } = new List<ReviewDetailsDto>();
}
