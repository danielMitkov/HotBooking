namespace HotBooking.Core.Models.DTOs.ReviewDtos;

public record ReviewEditDto(
int UserId,
Guid ReviewPublicId,
decimal Score,
string Title,
string Comment
);
