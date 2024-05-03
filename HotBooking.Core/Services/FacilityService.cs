using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class FacilityService : IFacilityService
{
    private readonly HotBookingDbContext dbContext;

    public FacilityService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<FacilityDetailsDto>> AllAsync()
    {
        var facilityDtos = await dbContext.Facilities.Select(f => new FacilityDetailsDto(
                f.PublicId,
                f.IsActive,
                f.Name,
                f.CreatedOn,
                f.SvgTag))
            .ToListAsync();

        return facilityDtos;
    }

    public async Task<FacilityDetailsDto> DetailsAsync(Guid id)
    {
        var facilityDto = await dbContext.Facilities
            .Where(f => f.PublicId == id)
            .Select(f => new FacilityDetailsDto(
                f.PublicId,
                f.IsActive,
                f.Name,
                f.CreatedOn,
                f.SvgTag))
            .SingleOrDefaultAsync();

        if (facilityDto == null)
        {
            throw new InvalidModelDataException(FacilityErrors.NotFound);
        }

        return facilityDto;
    }

    public async Task CreateAsync(FacilityPreviewDto facilityDto)
    {
        bool isFacilityNameTaken = await dbContext.Facilities
            .AnyAsync(f => f.Name.ToLower() == facilityDto.Name.ToLower());

        if (isFacilityNameTaken == true)
        {
            throw new InvalidModelDataException(FacilityErrors.NameAlreadyExists);
        }

        var facility = new Facility()
        {
            Name = facilityDto.Name,
            SvgTag = facilityDto.SvgTag
        };

        await dbContext.Facilities.AddAsync(facility);
        await dbContext.SaveChangesAsync();
    }

    public async Task<FacilityFormDto> GetByPublicId(Guid publicId)
    {
        var facilityDto = await dbContext.Facilities
            .Where(f => f.PublicId == publicId)
            .Select(f => new FacilityFormDto(
                f.PublicId,
                f.Name,
                f.SvgTag))
            .SingleOrDefaultAsync();

        if (facilityDto == null)
        {
            throw new InvalidModelDataException(FacilityErrors.NotFound);
        }

        return facilityDto;
    }

    public async Task UpdateAsync(FacilityFormDto formDto)
    {
        var facility = await dbContext.Facilities
            .SingleOrDefaultAsync(f => f.PublicId == formDto.PublicId);

        if (facility == null)
        {
            throw new InvalidModelDataException(FacilityErrors.NotFound);
        }

        facility.Name = formDto.Name;
        facility.SvgTag = formDto.SvgTag;

        await dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<FacilityChecksDto>> GetFacilityCheckboxesAsync(IEnumerable<Guid> selectedFacilityIds)
    {
        var allFacilities = await dbContext.Facilities.ToListAsync();

        var selectedFacilities = allFacilities.Where(f => selectedFacilityIds.Contains(f.PublicId));

        var facilityDtos = allFacilities.Select(f => new FacilityChecksDto(
                f.PublicId,
                selectedFacilities.Contains(f),
                f.Name,
                f.SvgTag))
            .ToList();

        return facilityDtos;
    }

    public async Task<string> DeleteAsync(Guid publicId)
    {
        var facility = await dbContext.Facilities
            .SingleOrDefaultAsync(f => f.PublicId == publicId);

        if (facility == null)
        {
            throw new InvalidModelDataException(FacilityErrors.NotFound);
        }

        if (facility.IsActive == false)
        {
            throw new InvalidModelDataException(FacilityErrors.AlreadyDeleted);
        }

        facility.IsActive = false;

        await dbContext.SaveChangesAsync();

        return facility.Name;
    }
}
