namespace HotBooking.Core.Models.DTOs.HotelDtos;

public record HotelDetailsDtoInput(
Guid PublicId,
int AdultsCount,
int RoomsCount,
DateTime CheckInDate,
DateTime CheckOutDate
);
