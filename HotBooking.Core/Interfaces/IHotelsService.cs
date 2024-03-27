using HotBooking.Core.DTOs.HotelDtos;

namespace HotBooking.Core.Interfaces;
public interface IHotelsService
{
    Task<BrowseHotelsOutputDto> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto, IDictionary<string, string> errors);
    Task<ICollection<string>> GetHotelsCitiesAsync(string searchTerm);
    //Task<string?> IsCityFoundAsync(string city);
}
