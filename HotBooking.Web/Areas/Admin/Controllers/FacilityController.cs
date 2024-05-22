using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Web.Models.FacilityViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Areas.Admin.Controllers
{
    public class FacilityController : BaseAdminController
    {
        public const string Name = "Facility";

        private readonly IFacilityService facilityService;
        private readonly ILogger<FacilityController> logger;

        public FacilityController(ILogger<FacilityController> logger,
            IFacilityService facilityService)
        {
            this.logger = logger;
            this.facilityService = facilityService;
        }

        public async Task<IActionResult> Index()
        {
            var facilityDtos = await facilityService.AllAsync();

            return View(facilityDtos);
        }

        public async Task<IActionResult> Details(Guid publicId)
        {
            try
            {
                var facilityDto = await facilityService.DetailsAsync(publicId);

                return View(facilityDto);
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
        public async Task<IActionResult> Create(FacilityCreateViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var facilityDto = new FacilityPreviewDto(
                model.Name,
                model.SvgTag);

            try
            {
                await facilityService.CreateAsync(facilityDto);

                TempData["OK"] = "Facility Created!";

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
                var facilityDto = await facilityService.GetByPublicId(publicId);

                var formModel = new FacilityFormViewModel()
                {
                    PublicId = facilityDto.PublicId,
                    Name = facilityDto.Name,
                    SvgTag = facilityDto.SvgTag
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
        public async Task<IActionResult> Edit(FacilityFormViewModel formModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(formModel);
            }

            var formDto = new FacilityFormDto(
                formModel.PublicId,
                formModel.Name,
                formModel.SvgTag);

            try
            {
                await facilityService.UpdateAsync(formDto);

                TempData["OK"] = "Facility Updated!";

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
                var facilityDto = await facilityService.DetailsAsync(publicId);

                return View(facilityDto);
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
                string name = await facilityService.DeleteAsync(publicId);

                TempData["OK"] = $"Facility '{name}' is Deleted!";
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
