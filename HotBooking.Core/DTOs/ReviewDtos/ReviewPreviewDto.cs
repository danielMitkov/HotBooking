namespace HotBooking.Core.DTOs.ReviewDtos;

public record ReviewPreviewDto(
decimal RatingScore,
string Title,
string Comment
);
