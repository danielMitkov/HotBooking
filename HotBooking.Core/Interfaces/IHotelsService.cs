using HotBooking.Core.DTOs.HotelDtos;

namespace HotBooking.Core.Interfaces;
public interface IHotelsService
{
    Task<ICollection<AllHotelDto>> AllHotelsAsync();
}
