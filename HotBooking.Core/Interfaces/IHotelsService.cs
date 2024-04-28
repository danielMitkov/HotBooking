using HotBooking.Core.Models.DTOs.HotelDtos;

namespace HotBooking.Core.Interfaces;

public interface IHotelsService
{
    Task<BrowseHotelsOutputDto> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto);
    Task<IEnumerable<string>> GetMatchingCitiesAsync(string searchTerm);
    Task<bool> IsCityFoundAsync(string city);
    Task<HotelDetailsDtoOutput> GetHotelDetailsAsync(HotelDetailsDtoInput inputDto);
    Task AddAsync(int userId, HotelAddDto addDto);
    Task<HotelEditDto> GetForEditAsync(int userId, Guid hotelId);
    Task EditAsync(int userId, HotelEditDto editDto);
    Task DeleteAsync(int userId, Guid hotelId);
}
