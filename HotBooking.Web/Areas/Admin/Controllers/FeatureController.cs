﻿using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Web.Areas.Admin.Controllers
{
    public class FeatureController : BaseAdminController
    {
        public const string Name = "Feature";

        private readonly HotBookingDbContext _context;

        public FeatureController(HotBookingDbContext context)
        {
            _context = context;
        }

        // GET: Features
        public async Task<IActionResult> Index()
        {
            return _context.Features != null ?
                        View(await _context.Features.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Features'  is null.");
        }

        // GET: Features/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // GET: Features/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublicId,IsActive,Name,CreatedOn,SvgTag")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        // GET: Features/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return View(feature);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PublicId,IsActive,Name,CreatedOn,SvgTag")] Feature feature)
        {
            if (id != feature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureExists(feature.Id))
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
            return View(feature);
        }

        // GET: Features/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Features == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Features'  is null.");
            }
            var feature = await _context.Features.FindAsync(id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureExists(int id)
        {
            return (_context.Features?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
