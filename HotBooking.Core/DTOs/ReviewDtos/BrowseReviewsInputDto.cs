namespace HotBooking.Core.DTOs.ReviewDtos;

public record BrowseReviewsInputDto(
Guid HotelId,
int CurrentPage,
int PageSize
);
