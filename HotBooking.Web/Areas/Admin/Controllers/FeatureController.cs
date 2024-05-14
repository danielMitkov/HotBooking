using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FeatureDtos;
using HotBooking.Web.Models.FeatureViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Areas.Admin.Controllers
{
    public class FeatureController : BaseAdminController
    {
        public const string Name = "Feature";

        private readonly IFeatureService featureService;
        private readonly ILogger<FeatureController> logger;

        public FeatureController(ILogger<FeatureController> logger,
            IFeatureService featureService)
        {
            this.logger = logger;
            this.featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            var featureDtos = await featureService.AllAsync();

            return View(featureDtos);
        }

        public async Task<IActionResult> Details(Guid publicId)
        {
            try
            {
                var featureDto = await featureService.DetailsAsync(publicId);

                return View(featureDto);
            }
            catch (InvalidModelDataException ex)
            {
                logger.LogWarning(ex, DateTime.Now.ToString());

                TempData["Error"] = ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeatureCreateViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var featureDto = new FeaturePreviewDto(
                model.Name,
                model.SvgTag);

            try
            {
                await featureService.CreateAsync(featureDto);

                TempData["OK"] = "Feature Created!";

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidModelDataException ex)
            {
                logger.LogWarning(ex, DateTime.Now.ToString());

                TempData["Error"] = ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(Guid publicId)
        {
            try
            {
                var featureDto = await featureService.GetByPublicId(publicId);

                var formModel = new FeatureFormViewModel()
                {
                    PublicId = featureDto.PublicId,
                    Name = featureDto.Name,
                    SvgTag = featureDto.SvgTag
                };

                return View(formModel);
            }
            catch (InvalidModelDataException ex)
            {
                logger.LogWarning(ex, DateTime.Now.ToString());

                TempData["Error"] = ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid publicId, FeatureFormViewModel formModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(formModel);
            }

            var formDto = new FeatureFormDto(
                formModel.PublicId,
                formModel.Name,
                formModel.SvgTag);

            try
            {
                await featureService.UpdateAsync(formDto);

                TempData["OK"] = "Feature Updated!";

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidModelDataException ex)
            {
                logger.LogWarning(ex, DateTime.Now.ToString());

                TempData["Error"] = ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(Guid publicId)
        {
            try
            {
                var featureDto = await featureService.DetailsAsync(publicId);

                return View(featureDto);
            }
            catch (InvalidModelDataException ex)
            {
                logger.LogWarning(ex, DateTime.Now.ToString());

                TempData["Error"] = ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid publicId)
        {
            try
            {
                string name = await featureService.DeleteAsync(publicId);

                TempData["OK"] = $"Feature '{name}' is Deleted!";
            }
            catch (InvalidModelDataException ex)
            {
                logger.LogWarning(ex, DateTime.Now.ToString());

                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
