using HotBooking.Core.DTOs.HotelDtos;

namespace HotBooking.Core.Interfaces;

public interface IHotelsService
{
    Task<BrowseHotelsOutputDto> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto);
    Task<ICollection<string>> GetMatchingCitiesAsync(string searchTerm);
    Task<bool> IsCityFoundAsync(string city);
    Task<HotelDetailsDto?> GetHotelDetailsAsync(Guid PublicId);
}
