using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.ReviewDtos;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models.ReviewViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class ReviewController : BaseController
{
    public const string Name = "Review";

    private readonly ILogger<ReviewController> logger;
    private readonly IReviewService reviewService;

    public ReviewController(
        ILogger<ReviewController> logger,
        IReviewService reviewService)
    {
        this.logger = logger;
        this.reviewService = reviewService;
    }

    [AllowAnonymous]
    [Route("Review/All/{page?}")]
    public async Task<IActionResult> All(Guid hotelPublicId, int page = 1)
    {
        var inputDto = new BrowseReviewsInputDto(User.GetId(), hotelPublicId, page, 2);

        try
        {
            var outputDto = await reviewService.GetReviewsForHotelAsync(inputDto);

            var browseModel = new ReviewBrowseViewModel()
            {
                HotelPublicId = hotelPublicId,
                Page = page,
                ReviewsCount = outputDto.ReviewsCount,
                Pager = new(outputDto.TotalPagesCount, page),
                CanAddReview = outputDto.CanAddReview,
                Reviews = outputDto.Reviews
            };

            return base.View(browseModel);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            TempData["Error"] = ex.Message;
            return base.RedirectToAction(nameof(HomeController.Index), HomeController.Name);
        }
    }

    public IActionResult Add(Guid hotelPublicId)
    {
        var addModel = new ReviewAddViewModel()
        {
            HotelPublicId = hotelPublicId
        };

        return View(addModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ReviewAddViewModel addModel)
    {
        if (ModelState.IsValid == false)
        {
            return View(addModel);
        }

        var inputDto = new ReviewAddDto(
            User.GetId(),
            addModel.HotelPublicId,
            addModel.RatingScore,
            addModel.Title,
            addModel.Comment);

        try
        {
            await reviewService.AddReviewAsync(inputDto);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            ModelState.AddModelError(ex.PropertyName, ex.Message);
        }

        TempData["OK"] = "Review is Added!";
        return RedirectToAction(nameof(All), new { hotelPublicId = addModel.HotelPublicId });
    }

    public async Task<IActionResult> Edit(Guid reviewPublicId, Guid hotelPublicId)
    {
        try
        {
            var reviewDto = await reviewService.GetReviewAsync(reviewPublicId);

            var editModel = new ReviewEditViewModel()
            {
                ReviewPublicId = reviewPublicId,
                HotelPublicId = hotelPublicId,
                RatingScore = reviewDto.RatingScore,
                Title = reviewDto.Title,
                Comment = reviewDto.Comment
            };

            return base.View(editModel);
        }
        catch (Core.Exceptions.InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            TempData["Error"] = ex.Message;
            return base.RedirectToAction(nameof(All), new { hotelPublicId });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ReviewEditViewModel editModel)
    {
        var inputDto = new ReviewEditDto(
            User.GetId(),
            editModel.ReviewPublicId,
            editModel.RatingScore,
            editModel.Title,
            editModel.Comment);

        try
        {
            await reviewService.EditAsync(inputDto);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            ModelState.AddModelError(ex.PropertyName, ex.Message);
            return base.View(editModel);
        }

        TempData["OK"] = "Review is Edited!";
        return RedirectToAction(nameof(All), new { hotelPublicId = editModel.HotelPublicId });
    }

    public async Task<IActionResult> Delete(Guid reviewPublicId, Guid hotelPublicId)
    {
        try
        {
            await reviewService.DeleteAsync(reviewPublicId, User.GetId());
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            TempData["Error"] = ex.Message;
        }

        TempData["OK"] = "Review is Deleted!";
        return RedirectToAction(nameof(All), new { hotelPublicId });
    }
}
