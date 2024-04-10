using HotBooking.Core.DTOs.ReviewDtos;

namespace HotBooking.Core.Interfaces;

public interface IReviewService
{
    Task<BrowseReviewsOutputDto?> GetReviewsForHotel(BrowseReviewsInputDto inputDto);
}
