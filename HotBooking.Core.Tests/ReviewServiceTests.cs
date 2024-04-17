using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Models.DTOs.ReviewDtos;
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

    private const decimal score = 5.5m;
    private const string title = "Test Title";
    private const string comment = "Test Comment";

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

    [Fact]
    public async Task DeleteAsync_ThrowsFor_NotAuthor()
    {
        var reviewPublicId = seeder.Review_NormalUser_ChilworthLondonPaddington.PublicId;
        int userId = -1;

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => reviewService.DeleteAsync(reviewPublicId, userId));

        Assert.Equal(ReviewErrors.NotTheAuthorOfReview, ex.Message);
    }

    [Fact]
    public async Task AddReviewAsync_ThrowsFor_AlreadyHasReview()
    {
        var inputDto = new ReviewAddDto(
            seeder.User_Normal.Id,
            seeder.Hotel_ChilworthLondonPaddington.PublicId,
            score,
            title,
            comment);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => reviewService.AddReviewAsync(inputDto));

        Assert.Equal(ReviewErrors.AlreadyHasReview, ex.Message);
    }

    [Fact]
    public async Task AddReviewAsync_ThrowsFor_BookingNotFound()
    {
        var inputDto = new ReviewAddDto(
            seeder.User_Normal.Id,
            seeder.Hotel_StrandPalace.PublicId,
            score,
            title,
            comment);

        var ex = await Assert.ThrowsAsync<InvalidModelDataException>(
            () => reviewService.AddReviewAsync(inputDto));

        Assert.Equal(BookingErrors.NotFound, ex.Message);
    }

    [Fact]
    public async Task EditAsync_Works()
    {
        var reviewPublicId = seeder.Review_NormalUser_ChilworthLondonPaddington.PublicId;

        var editDto = new ReviewEditDto(
            seeder.User_Normal.Id,
            reviewPublicId,
            score,
            title,
            comment);

        await reviewService.EditAsync(editDto);

        var editedReview = await dbContext.Reviews
            .SingleAsync(r => r.PublicId == reviewPublicId);

        Assert.NotNull(editedReview);
        Assert.Equal(editedReview.RatingScore, score);
        Assert.Equal(editedReview.Title, title);
        Assert.Equal(editedReview.Comment, comment);
    }

    [Fact]
    public async Task GetReviewsForHotel_Works()
    {
        var hotelPublicId = seeder.Hotel_ChilworthLondonPaddington.PublicId;

        var inputDto = new BrowseReviewsInputDto(
            seeder.User_Normal.Id,
            hotelPublicId,
            1,
            1);

        var outputDto = await reviewService.GetReviewsForHotelAsync(inputDto);

        int expectedReviewCount = await dbContext.Reviews
            .Where(r => r.HotelId == seeder.Hotel_ChilworthLondonPaddington.Id)
            .CountAsync();

        Assert.Equal(expectedReviewCount, outputDto.ReviewsCount);
        Assert.Single(outputDto.Reviews);
    }
}
