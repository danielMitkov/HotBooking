namespace HotBooking.Core.DTOs.ReviewDtos;

public record AddReviewInputDto(
string UserId,
Guid HotelId,
decimal RatingScore,
string Title,
string Comment
);
