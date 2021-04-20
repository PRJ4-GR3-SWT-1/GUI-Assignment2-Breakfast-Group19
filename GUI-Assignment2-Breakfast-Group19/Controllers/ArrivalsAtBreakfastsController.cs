﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_Assignment2_Breakfast_Group19.Data;
using GUI_Assignment2_Breakfast_Group19.Models;

namespace GUI_Assignment2_Breakfast_Group19.Controllers
{
    public class ArrivalsAtBreakfastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArrivalsAtBreakfastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArrivalsAtBreakfasts
        public async Task<IActionResult> Index()
        {
            var sd = new SeedData(_context);
            var arrivals = _context.ArrivalsAtBreakfast
                .Include(a => a.BreakfastAttendees)
                .SingleOrDefault(a => a.Date.Date == DateTime.Today.Date);
            if (arrivals == null)
            {
                arrivals = (ArrivalsExtended) new ArrivalsAtBreakfast() {Date = DateTime.Today};
                _context.ArrivalsAtBreakfast.Add(arrivals);
                _context.SaveChanges();
            }
            //Get reservations:
            var res = _context.BreakfastReservations
                .Include(r => r.BreakfastReservationList)
                .SingleOrDefault(r => r.Date.Date == DateTime.Today.Date);
            var resNumber = res?.GetNumberOfAdultsAndChildren();
            ArrivalsExtended arrivalsExtended = new ArrivalsExtended(arrivals);
            if (resNumber != null)
            {
                    arrivalsExtended.AdultReservations = resNumber[0];
                    arrivalsExtended.ChildReservations = resNumber[1];
            }

            return View(arrivalsExtended);
        }

        // GET: ArrivalsAtBreakfasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivalsAtBreakfast = await _context.ArrivalsAtBreakfast
                .FirstOrDefaultAsync(m => m.ArrivalsAtBreakfastId == id);
            if (arrivalsAtBreakfast == null)
            {
                return NotFound();
            }

            return View(arrivalsAtBreakfast);
        }

        // GET: ArrivalsAtBreakfasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArrivalsAtBreakfasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArrivalsAtBreakfastId,Date")] ArrivalsAtBreakfast arrivalsAtBreakfast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrivalsAtBreakfast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arrivalsAtBreakfast);
        }

        // GET: ArrivalsAtBreakfasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivalsAtBreakfast = await _context.ArrivalsAtBreakfast.FindAsync(id);
            if (arrivalsAtBreakfast == null)
            {
                return NotFound();
            }
            return View(arrivalsAtBreakfast);
        }

        // POST: ArrivalsAtBreakfasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArrivalsAtBreakfastId,Date")] ArrivalsAtBreakfast arrivalsAtBreakfast)
        {
            if (id != arrivalsAtBreakfast.ArrivalsAtBreakfastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrivalsAtBreakfast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrivalsAtBreakfastExists(arrivalsAtBreakfast.ArrivalsAtBreakfastId))
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
            return View(arrivalsAtBreakfast);
        }

        // GET: ArrivalsAtBreakfasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivalsAtBreakfast = await _context.ArrivalsAtBreakfast
                .FirstOrDefaultAsync(m => m.ArrivalsAtBreakfastId == id);
            if (arrivalsAtBreakfast == null)
            {
                return NotFound();
            }

            return View(arrivalsAtBreakfast);
        }

        // POST: ArrivalsAtBreakfasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arrivalsAtBreakfast = await _context.ArrivalsAtBreakfast
                .Include(b => b.BreakfastAttendees)
                .FirstOrDefaultAsync(m => m.ArrivalsAtBreakfastId == id);

            foreach (var room in arrivalsAtBreakfast.BreakfastAttendees)
            {
                _context.Remove(_context.Room.Single(r => r.RoomId == room.RoomId));
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrivalsAtBreakfastExists(int id)
        {
            return _context.ArrivalsAtBreakfast.Any(e => e.ArrivalsAtBreakfastId == id);
        }
    }
}
