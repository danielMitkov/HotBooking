using HotBooking.Core.Models.Enums;

namespace HotBooking.Core.Models.DTOs.BookingDtos;

public class BookingListDto
{
    public Guid BookingPublicId { get; set; }

    public string RoomImageUrl { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public int AdultsCount { get; set; }

    public string RoomTitle { get; set; } = null!;

    public string HotelName { get; set; } = null!;

    public string HotelLocation { get; set; } = null!;

    public BookingStatus Status { get; set; }
}
