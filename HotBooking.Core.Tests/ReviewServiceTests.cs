using HotBooking.Core.DTOs.ReviewDtos;
using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Services;
using HotBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Tests;
public class ReviewServiceTests : IDisposable
{
    private DbContextOptions<HotBookingDbContext> dbOptions;
    private HotBookingDbContext dbContext;

    private DataSeeder seeder;

    private ReviewService reviewService;

    public ReviewServiceTests()
    {
        dbOptions = new DbContextOptionsBuilder<HotBookingDbContext>()
                .UseInMemoryDatabase("HotBookingInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
        dbContext = new HotBookingDbContext(dbOptions);
        dbContext.Database.EnsureCreated();

        seeder = new DataSeeder();

        reviewService = new ReviewService(dbContext);
    }

    public void Dispose()
    {
        dbContext.Database.EnsureDeleted();
    }

    [Fact]
    public async Task GetByPublicId_ThrowsFor_NotFound()
    {
        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => reviewService.GetReviewAsync(Guid.NewGuid()));

        Assert.Equal(ReviewErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task GetByPublicId_Returns_Correct()
    {
        var review = seeder.Review_NormalUser_ChilworthLondonPaddington;

        var outputDto = await reviewService.GetReviewAsync(review.PublicId);

        Assert.Equal(review.RatingScore, outputDto.RatingScore);
        Assert.Equal(review.Title, outputDto.Title);
        Assert.Equal(review.Comment, outputDto.Comment);
    }

    [Fact]
    public async Task AddReviewAsync_Works_Correctly()
    {
        decimal score = 5.5m;
        string title = "Test Title";
        string comment = "Test Comment";

        var hotelPublicId = seeder.Hotel_KempinskiHotelGrandArena.PublicId;

        var inputDto = new ReviewAddDto(
            seeder.User_Normal.Id,
            hotelPublicId,
            score,
            title,
            comment);

        await reviewService.AddReviewAsync(inputDto);

        var expectedReview = dbContext.Reviews
            .SingleOrDefault(r => r.Title == title);

        Assert.NotNull(expectedReview);
    }
}
