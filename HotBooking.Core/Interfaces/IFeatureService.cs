using HotBooking.Core.Models.DTOs.FeatureDtos;

namespace HotBooking.Core.Interfaces;

public interface IFeatureService
{
    Task<IEnumerable<FeatureDetailsDto>> AllAsync();
    Task<FeatureDetailsDto> DetailsAsync(Guid id);
    Task CreateAsync(FeaturePreviewDto facilityDto);
    Task<FeatureFormDto> GetByPublicId(Guid publicId);
    Task UpdateAsync(FeatureFormDto formDto);
    Task<ICollection<FeatureChecksDto>> GetFeatureCheckboxesAsync(IEnumerable<Guid> selectedFeatureIds);
    Task<string> DeleteAsync(Guid id);
}
