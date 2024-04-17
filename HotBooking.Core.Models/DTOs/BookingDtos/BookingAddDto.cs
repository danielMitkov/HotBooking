namespace HotBooking.Core.Models.DTOs.BookingDtos;

public record BookingAddDto(
int UserId,
Guid RoomId,
DateTime CheckIn,
DateTime CheckOut,
int AdultsCount
);
