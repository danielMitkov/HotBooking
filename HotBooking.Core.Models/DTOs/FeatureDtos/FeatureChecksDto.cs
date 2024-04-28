namespace HotBooking.Core.Models.DTOs.FeatureDtos;

public record FeatureChecksDto(
Guid PublicId,
bool IsChecked,
string Name,
string SvgTag);
