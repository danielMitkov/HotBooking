namespace HotBooking.Core.DTOs.ReviewDtos;

public record ReviewEditDto(
int UserId,
Guid ReviewPublicId,
decimal Score,
string Title,
string Comment
);
