namespace HotBooking.Core.DTOs.FacilityDtos;

public record FacilityChecksDto(
Guid PublicId, 
bool IsChecked, 
string Name, 
string SvgTag
);
