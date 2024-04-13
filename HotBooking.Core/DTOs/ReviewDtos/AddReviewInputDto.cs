namespace HotBooking.Core.DTOs.ReviewDtos;

public record AddReviewInputDto(
int UserId,
Guid HotelId,
decimal RatingScore,
string Title,
string Comment
);
