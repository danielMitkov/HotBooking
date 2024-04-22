namespace HotBooking.Core.Models.DTOs.FacilityDtos;

public record FacilityControlDetailsDto(
Guid PublicId,
bool IsActive,
string Name,
DateTime CreatedOn,
string SvgTag
);
