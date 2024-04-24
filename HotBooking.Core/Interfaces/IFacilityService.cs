﻿using HotBooking.Core.Models.DTOs.FacilityDtos;

namespace HotBooking.Core.Interfaces;

public interface IFacilityService
{
    Task<IEnumerable<FacilityControlDetailsDto>> AllAsync();
    Task<FacilityControlDetailsDto> DetailsAsync(Guid id);
    Task CreateAsync(FacilityDetailsDto facilityDto);
    Task<FacilityFormDto> GetByPublicId(Guid publicId);
    Task UpdateAsync(FacilityFormDto formDto);
    Task<ICollection<FacilityChecksDto>> GetFacilityCheckboxesAsync(IEnumerable<Guid> selectedFacilityIds);
}
