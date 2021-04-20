using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_Assignment2_Breakfast_Group19.Data;
using GUI_Assignment2_Breakfast_Group19.Models;
using Microsoft.AspNetCore.Authorization;

namespace GUI_Assignment2_Breakfast_Group19.Controllers
{
    public class BreakfastReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BreakfastReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Policy = "CanAccessReception")]
        // GET: BreakfastReservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BreakfastReservations
                .OrderBy(r=>r.Date)
                .Include(r =>r.BreakfastReservationList)
                .ToListAsync());
        }

        // GET: BreakfastReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservations = await _context.BreakfastReservations
                .Include(b=>b.BreakfastReservationList)
                .FirstOrDefaultAsync(m => m.BreakfastReservationsId == id);
            if (breakfastReservations == null)
            {
                return NotFound();
            }

            return View(breakfastReservations);
        }

        // GET: BreakfastReservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BreakfastReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BreakfastReservationsId,Date")] BreakfastReservations breakfastReservations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakfastReservations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breakfastReservations);
        }

        // GET: BreakfastReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservations = await _context.BreakfastReservations.FindAsync(id);
            if (breakfastReservations == null)
            {
                return NotFound();
            }
            return View(breakfastReservations);
        }

        // POST: BreakfastReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BreakfastReservationsId,Date")] BreakfastReservations breakfastReservations)
        {
            if (id != breakfastReservations.BreakfastReservationsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakfastReservations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakfastReservationsExists(breakfastReservations.BreakfastReservationsId))
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
            return View(breakfastReservations);
        }

        // GET: BreakfastReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservations = await _context.BreakfastReservations
                .FirstOrDefaultAsync(m => m.BreakfastReservationsId == id);

            if (breakfastReservations == null)
            {
                return NotFound();
            }

            return View(breakfastReservations);
        }

        // POST: BreakfastReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breakfastReservations = await _context.BreakfastReservations
                .Include(b => b.BreakfastReservationList)
                .FirstOrDefaultAsync(m => m.BreakfastReservationsId == id);

            foreach (var room in breakfastReservations.BreakfastReservationList)
            {
                _context.Remove(_context.Room.Single(r => r.RoomId == room.RoomId));
            }

            await _context.SaveChangesAsync();

            _context.BreakfastReservations.Remove(breakfastReservations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakfastReservationsExists(int id)
        {
            return _context.BreakfastReservations.Any(e => e.BreakfastReservationsId == id);
        }
    }
}
