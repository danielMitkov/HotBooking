using HotBooking.Core.Models.DTOs.ReviewDtos;

namespace HotBooking.Core.Interfaces;

public interface IReviewService
{
    Task<ReviewPreviewDto> GetReviewAsync(Guid reviewPublicId);
    Task<ReviewBrowseOutputDto> GetReviewsForHotelAsync(BrowseReviewsInputDto inputDto);
    Task AddReviewAsync(ReviewAddDto addDto);
    Task DeleteAsync(Guid reviewPublicId, int userId);
    Task EditAsync(ReviewEditDto editDto);
}
