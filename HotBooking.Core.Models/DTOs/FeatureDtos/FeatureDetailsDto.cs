namespace HotBooking.Core.Models.DTOs.FeatureDtos;

public record FeatureDetailsDto(
Guid PublicId,
bool IsActive,
string Name,
DateTime CreatedOn,
string SvgTag
);
