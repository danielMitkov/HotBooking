using HotBooking.Core.Models.DTOs.FacilityDtos;

namespace HotBooking.Core.Interfaces;

public interface IFacilityService
{
    Task<IEnumerable<FacilityDetailsDto>> AllAsync();
    Task<FacilityDetailsDto> DetailsAsync(Guid id);
    Task CreateAsync(FacilityPreviewDto facilityDto);
    Task<FacilityFormDto> GetByPublicId(Guid publicId);
    Task UpdateAsync(FacilityFormDto formDto);
    Task<ICollection<FacilityChecksDto>> GetFacilityCheckboxesAsync(IEnumerable<Guid> selectedFacilityIds);
    Task<string> DeleteAsync(Guid id);
}
