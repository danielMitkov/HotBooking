using HotBooking.Core.Models.DTOs.FacilityDtos;

namespace HotBooking.Core.Interfaces;

public interface IFacilityService
{
    Task<IEnumerable<FacilityControlDetailsDto>> AllAsync();
    Task<FacilityControlDetailsDto> DetailsAsync(Guid id);
}
