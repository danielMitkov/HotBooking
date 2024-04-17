namespace HotBooking.Core.Models.DTOs.ReviewDtos;

public record BrowseReviewsInputDto(
int UserId,
Guid HotelId,
int CurrentPage,
int PageSize
);
