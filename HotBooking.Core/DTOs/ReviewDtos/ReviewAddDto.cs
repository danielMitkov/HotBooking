namespace HotBooking.Core.DTOs.ReviewDtos;

public record ReviewAddDto(
int UserId,
Guid HotelPublicId,
decimal Score,
string Title,
string Comment
);
