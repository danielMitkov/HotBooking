using HotBooking.Core.Models.DTOs.FeatureDtos;

namespace HotBooking.Core.Interfaces;

public interface IFeatureService
{
    Task<ICollection<FeatureChecksDto>> GetFeatureCheckboxesAsync(IEnumerable<Guid> selectedFeatureIds);
}
