namespace HotBooking.Core.DTOs.FacilityDtos;

public record FacilityDto(
    Guid PublicId, 
    bool IsChecked, 
    string Name, 
    string SvgTag
);