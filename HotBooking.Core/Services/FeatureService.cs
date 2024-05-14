using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FeatureDtos;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class FeatureService : IFeatureService
{
    private readonly HotBookingDbContext dbContext;

    public FeatureService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<FeatureDetailsDto>> AllAsync()
    {
        var featureDtos = await dbContext.Features
            .Select(f => new FeatureDetailsDto(
                f.PublicId,
                f.IsActive,
                f.Name,
                f.CreatedOn,
                f.SvgTag))
            .ToListAsync();

        return featureDtos;
    }

    public async Task<FeatureDetailsDto> DetailsAsync(Guid id)
    {
        var featureDto = await dbContext.Features
            .Where(f => f.PublicId == id)
            .Select(f => new FeatureDetailsDto(
                f.PublicId,
                f.IsActive,
                f.Name,
                f.CreatedOn,
                f.SvgTag))
            .SingleOrDefaultAsync();

        if (featureDto == null)
        {
            throw new InvalidModelDataException(FeatureErrors.NotFound);
        }

        return featureDto;
    }

    public async Task CreateAsync(FeaturePreviewDto featureDto)
    {
        bool isFeatureNameTaken = await dbContext.Features
            .AnyAsync(f => f.Name.ToLower() == featureDto.Name.ToLower());

        if (isFeatureNameTaken == true)
        {
            throw new InvalidModelDataException(FeatureErrors.NameAlreadyExists);
        }

        var feature = new Feature()
        {
            Name = featureDto.Name,
            SvgTag = featureDto.SvgTag
        };

        await dbContext.Features.AddAsync(feature);
        await dbContext.SaveChangesAsync();
    }

    public async Task<FeatureFormDto> GetByPublicId(Guid publicId)
    {
        var featureDto = await dbContext.Features
            .Where(f => f.PublicId == publicId)
            .Select(f => new FeatureFormDto(
                f.PublicId,
                f.Name,
                f.SvgTag))
            .SingleOrDefaultAsync();

        if (featureDto == null)
        {
            throw new InvalidModelDataException(FeatureErrors.NotFound);
        }

        return featureDto;
    }

    public async Task UpdateAsync(FeatureFormDto formDto)
    {
        var feature = await dbContext.Features
            .SingleOrDefaultAsync(f => f.PublicId == formDto.PublicId);

        if (feature == null)
        {
            throw new InvalidModelDataException(FeatureErrors.NotFound);
        }

        feature.Name = formDto.Name;
        feature.SvgTag = formDto.SvgTag;

        await dbContext.SaveChangesAsync();
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

    public async Task<string> DeleteAsync(Guid publicId)
    {
        var feature = await dbContext.Features
            .SingleOrDefaultAsync(f => f.PublicId == publicId);

        if (feature == null)
        {
            throw new InvalidModelDataException(FeatureErrors.NotFound);
        }

        if (feature.IsActive == false)
        {
            throw new InvalidModelDataException(FeatureErrors.AlreadyDeleted);
        }

        feature.IsActive = false;

        await dbContext.SaveChangesAsync();

        return feature.Name;
    }
}
