using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FeatureDtos;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;

public class FeatureServiceTests
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private IFeatureService featureService;

    private const string featureName = "Test Name";
    private const string svgTag = "Test SvgTag";

    public FeatureServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
                .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();

        seeder = new DataSeeder();

        featureService = new FeatureService(dbContext);
    }

    [Fact]
    public async Task DeleteAsync_ThrowsFor_AlreadyDeleted()
    {
        var publicId = seeder.Feature_Hairdryer.PublicId;

        await featureService.DeleteAsync(publicId);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => featureService.DeleteAsync(publicId));

        Assert.Equal(FeatureErrors.AlreadyDeleted, ex.Message);
    }

    [Fact]
    public async Task DeleteAsync_ThrowsFor_NotFound()
    {
        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => featureService.DeleteAsync(Guid.NewGuid()));

        Assert.Equal(FeatureErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task DeleteAsync_Works()
    {
        var expectedFeature = seeder.Feature_TV;
        var publicId = expectedFeature.PublicId;
        //
        string name = await featureService.DeleteAsync(publicId);

        var feature = await dbContext.Features
            .FirstAsync(f => f.PublicId == publicId);

        Assert.False(feature.IsActive);
        Assert.Equal(expectedFeature.Name, name);
    }

    [Fact]
    public async Task DetailsAsync_ThrowsFor_NotFound()
    {
        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => featureService.DetailsAsync(Guid.NewGuid()));

        Assert.Equal(FeatureErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task CreateAsync_ThrowsFor_NameAlreadyExists()
    {
        var featureDto = new FeaturePreviewDto(
            seeder.Features.First().Name,
            svgTag);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => featureService.CreateAsync(featureDto));

        Assert.Equal(FeatureErrors.NameAlreadyExists, ex.Message);
    }

    [Fact]
    public async Task CreateAsync_WorksCorrectly()
    {
        var featureDto = new FeaturePreviewDto(
            featureName,
            svgTag);

        await featureService.CreateAsync(featureDto);

        var feature = await dbContext.Features
            .FirstOrDefaultAsync(f => f.Name == featureName && f.SvgTag == svgTag);

        Assert.NotNull(feature);
    }

    [Fact]
    public async Task GetByPublicId_ThrowsFor_NotFound()
    {
        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => featureService.GetByPublicId(Guid.NewGuid()));

        Assert.Equal(FeatureErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task GetByPublicId_WorksCorrectly()
    {
        var feature = seeder.Feature_TV;

        var featureDto = await featureService.GetByPublicId(feature.PublicId);

        Assert.Equal(feature.PublicId, featureDto.PublicId);
        Assert.Equal(feature.Name, featureDto.Name);
        Assert.Equal(feature.SvgTag, featureDto.SvgTag);
    }

    [Fact]
    public async Task UpdateAsync_ThrowsFor_FacilityNotFound()
    {
        var formDto = new FeatureFormDto(
            Guid.NewGuid(),
            featureName,
            svgTag);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => featureService.UpdateAsync(formDto));

        Assert.Equal(FeatureErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task UpdateAsync_Updates()
    {
        var feature = seeder.Feature_TV;

        var formDto = new FeatureFormDto(
            feature.PublicId,
            featureName,
            svgTag);

        await featureService.UpdateAsync(formDto);

        var featureUpdated = await dbContext.Features
            .SingleAsync(f => f.Id == feature.Id);

        Assert.NotNull(featureUpdated);
        Assert.Equal(featureName, featureUpdated.Name);
        Assert.Equal(svgTag, featureUpdated.SvgTag);
    }
}
