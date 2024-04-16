namespace HotBooking.Core.DTOs.ReviewDtos;

public record ReviewBrowseOutputDto(
bool CanAddReview,
IEnumerable<ReviewDetailsDto> Reviews,
int TotalPagesCount,
int ReviewsCount
);
