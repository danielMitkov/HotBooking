namespace HotBooking.Core.DTOs.ReviewDtos;

public record BrowseReviewsOutputDto(
IEnumerable<ReviewDetailsDto> Reviews,
int TotalPagesCount,
int ReviewsCount
);
