using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Data;
using HotBooking.Data.Models;
using HotBooking.Web.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Web.Areas.Admin.Controllers
{
    public class FacilityController : BaseAdminController
    {
        public const string Name = "Facility";

        private readonly HotBookingDbContext _context;
        private readonly IFacilityService facilityService;
        private readonly ILogger<FacilityController> logger;

        public FacilityController(HotBookingDbContext context,
            IFacilityService facilityService,
            ILogger<FacilityController> logger)
        {
            _context = context;
            this.facilityService = facilityService;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var facilityDtos = await facilityService.AllAsync();

            return View(facilityDtos);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var facilityDto = await facilityService.DetailsAsync(id);

                return View(facilityDto);
            }
            catch (InvalidModelDataException ex)
            {
                logger.LogWarning(ex, DateTime.Now.ToString());

                TempData["Error"] = ex.Message;

                return RedirectToAction(
                    nameof(HomeController.Index),
                    HomeController.Name,
                    new { Area = AdminConstants.AdminAreaName });
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SvgTag")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facility);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }
            return View(facility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PublicId,IsActive,Name,CreatedOn,SvgTag")] Facility facility)
        {
            if (id != facility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityExists(facility.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(facility);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facilities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Facilities'  is null.");
            }
            var facility = await _context.Facilities.FindAsync(id);
            if (facility != null)
            {
                _context.Facilities.Remove(facility);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int id)
        {
            return (_context.Facilities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
