namespace HotBooking.Core.Models.DTOs.ReviewDtos;

public record ReviewBrowseOutputDto(
bool CanAddReview,
IEnumerable<ReviewDetailsDto> Reviews,
int TotalPagesCount,
int ReviewsCount
);
