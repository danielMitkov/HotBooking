using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class FacilityService : IFacilityService
{
    private readonly HotBookingDbContext dbContext;

    public FacilityService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<FacilityControlDetailsDto>> AllAsync()
    {
        var facilityDtos = await dbContext.Facilities
            .Select(f => new FacilityControlDetailsDto(
                f.PublicId,
                f.IsActive,
                f.Name,
                f.CreatedOn,
                f.SvgTag))
            .ToListAsync();

        return facilityDtos;
    }

    public async Task<FacilityControlDetailsDto> DetailsAsync(Guid id)
    {
        var facilityDto = await dbContext.Facilities
            .Where(f => f.PublicId == id)
            .Select(f => new FacilityControlDetailsDto(
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
}
