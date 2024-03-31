using HotBooking.Core.DTOs.HotelDtos;

namespace HotBooking.Core.Interfaces;

public interface IHotelsService:IErrorMessageProp
{
    Task<BrowseHotelsOutputDto?> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto);
    Task<ICollection<string>> GetHotelsCitiesAsync(string searchTerm);
    //Task<string?> IsCityFoundAsync(string city);
}
