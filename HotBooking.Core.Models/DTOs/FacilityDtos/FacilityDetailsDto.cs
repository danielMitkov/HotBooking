namespace HotBooking.Core.Models.DTOs.FacilityDtos;

public record FacilityDetailsDto(
Guid PublicId,
bool IsActive,
string Name,
DateTime CreatedOn,
string SvgTag
);
