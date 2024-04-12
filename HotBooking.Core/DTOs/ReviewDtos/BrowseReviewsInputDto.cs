namespace HotBooking.Core.DTOs.ReviewDtos;

public record BrowseReviewsInputDto(
string? UserId,
Guid HotelId,
int CurrentPage,
int PageSize
);
