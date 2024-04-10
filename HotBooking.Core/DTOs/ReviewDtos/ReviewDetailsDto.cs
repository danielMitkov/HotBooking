namespace HotBooking.Core.DTOs.ReviewDtos;

public record ReviewDetailsDto(
decimal Score,
string Title,
string Comment,
DateTime ReviewedOnDate,
DateTime CheckInDate,
DateTime CheckOutDate,
int AdultsCount,
string RoomTitle
);
