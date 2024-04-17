namespace HotBooking.Core.Models.DTOs.ReviewDtos;

public record ReviewPreviewDto(
decimal RatingScore,
string Title,
string Comment
);
