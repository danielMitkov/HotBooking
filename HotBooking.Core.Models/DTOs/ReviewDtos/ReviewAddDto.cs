namespace HotBooking.Core.Models.DTOs.ReviewDtos;

public record ReviewAddDto(
int UserId,
Guid HotelPublicId,
decimal Score,
string Title,
string Comment
);
