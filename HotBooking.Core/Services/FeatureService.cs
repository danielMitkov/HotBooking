using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FeatureDtos;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class FeatureService : IFeatureService
{
    private readonly HotBookingDbContext dbContext;

    public FeatureService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ICollection<FeatureChecksDto>> GetFeatureCheckboxesAsync(IEnumerable<Guid> selectedFeatureIds)
    {
        var allFeatures = await dbContext.Features
            .ToListAsync();

        var selectedFeatures = allFeatures
            .Where(f => selectedFeatureIds.Contains(f.PublicId));

        var featureDtos = allFeatures
            .Select(f => new FeatureChecksDto(
                f.PublicId,
                selectedFeatures.Contains(f),
                f.Name,
                f.SvgTag))
            .ToList();

        return featureDtos;
    }
}
