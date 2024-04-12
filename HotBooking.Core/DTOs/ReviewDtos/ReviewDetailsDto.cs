namespace HotBooking.Core.DTOs.ReviewDtos;

public record ReviewDetailsDto(
bool IsAuthor,
decimal Score,
string Title,
string Comment,
DateTime ReviewedOnDate,
DateTime CheckInDate,
DateTime CheckOutDate,
int AdultsCount,
string RoomTitle
);
