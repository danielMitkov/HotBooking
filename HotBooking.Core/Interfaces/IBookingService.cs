using HotBooking.Core.Models.DTOs.BookingDtos;

namespace HotBooking.Core.Interfaces;

public interface IBookingService
{
    Task AddAsync(BookingAddDto addDto);
    Task<ICollection<BookingListDto>> GetBookingsAsync(int userId);
    Task CancelAsync(Guid id);
}
