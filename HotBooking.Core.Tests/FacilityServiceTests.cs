using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;

public class FacilityServiceTests
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private IFacilityService facilityService;

    private const string facilityName = "Test Name";
    private const string svgTag = "Test SvgTag";

    public FacilityServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
                .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();

        seeder = new DataSeeder();

        facilityService = new FacilityService(dbContext);
    }

    [Fact]
    public async Task DetailsAsync_ThrowsFor_NotFound()
    {
        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => facilityService.DetailsAsync(Guid.NewGuid()));

        Assert.Equal(FacilityErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task CreateAsync_ThrowsFor_NameAlreadyExists()
    {
        var facilityDto = new FacilityDetailsDto(
            seeder.Facilities.First().Name,
            svgTag);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => facilityService.CreateAsync(facilityDto));

        Assert.Equal(FacilityErrors.NameAlreadyExists, ex.Message);
    }

    [Fact]
    public async Task CreateAsync_WorksCorrectly()
    {
        var facilityDto = new FacilityDetailsDto(
            facilityName,
            svgTag);

        await facilityService.CreateAsync(facilityDto);

        var facility = await dbContext.Facilities
            .FirstOrDefaultAsync(f => f.Name == facilityName && f.SvgTag == svgTag);

        Assert.NotNull(facility);
    }

    [Fact]
    public async Task GetByPublicId_ThrowsFor_NotFound()
    {
        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => facilityService.GetByPublicId(Guid.NewGuid()));

        Assert.Equal(FacilityErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task GetByPublicId_WorksCorrectly()
    {
        var facility = seeder.Facility_Spa;

        var facilityDto = await facilityService.GetByPublicId(facility.PublicId);

        Assert.Equal(facility.PublicId, facilityDto.PublicId);
        Assert.Equal(facility.Name, facilityDto.Name);
        Assert.Equal(facility.SvgTag, facilityDto.SvgTag);
    }

    [Fact]
    public async Task UpdateAsync_ThrowsFor_FacilityNotFound()
    {
        var formDto = new FacilityFormDto(
            Guid.NewGuid(),
            facilityName,
            svgTag);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => facilityService.UpdateAsync(formDto));

        Assert.Equal(FacilityErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task UpdateAsync_Updates()
    {
        var formDto = new FacilityFormDto(
            seeder.Facility_Spa.PublicId,
            facilityName,
            svgTag);

        await facilityService.UpdateAsync(formDto);

        var facilityUpdated = await dbContext.Facilities
            .SingleAsync(f => f.Id == seeder.Facility_Spa.Id);

        Assert.NotNull(facilityUpdated);
        Assert.Equal(facilityName, facilityUpdated.Name);
        Assert.Equal(svgTag, facilityUpdated.SvgTag);
    }
}
