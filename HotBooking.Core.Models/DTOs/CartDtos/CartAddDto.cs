namespace HotBooking.Core.Models.DTOs.CartDtos;

public record CartAddDto(
int UserId,
Guid RoomId,
DateTime CheckIn,
DateTime CheckOut,
int AdultsCount,
int RoomsCount
);
