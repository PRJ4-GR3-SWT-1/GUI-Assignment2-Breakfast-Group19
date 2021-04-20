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
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room.ToListAsync());
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
        [Authorize(Policy = "CanAccessReception")]
        // GET: Room/Create
        public IActionResult CreateReservation()
        {
            return View(new RoomExtended(){date = DateTime.Today.Date});
        }
        [Authorize(Policy = "CanCheckInGuests")]
        // GET: Room/Create
        public IActionResult CreateArrival()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Policy = "CanAccessReception")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation([Bind("RoomId,RoomNumber,Adults,Children,date")] RoomExtended room)
        {
            if (ModelState.IsValid)
            {
                DateTime date;
                if(room.date==new DateTime())  date=DateTime.Today;
                else
                {
                    date = room.date;
                }
                var res = _context.BreakfastReservations.SingleOrDefault(b => b.Date.Date== date.Date);
                if (res == null) return Content("Date not found");
                res.BreakfastReservationList.Add(room);
                //_context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),nameof(BreakfastReservations));
            }
            return RedirectToAction(nameof(Index), nameof(BreakfastReservations));
        }

        [Authorize(Policy = "CanCheckInGuests")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArrival([Bind("RoomId,RoomNumber,Adults,Children")] Room room)
        {
            if (ModelState.IsValid)
            {
                var res = _context.ArrivalsAtBreakfast.SingleOrDefault(b => b.Date.Date == DateTime.Today.Date);
                if (res == null) return Content("Date not found");
                res.BreakfastAttendees.Add(room);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index), "ArrivalsAtBreakfasts");
        }

        [Authorize(Policy = "CanEditRooms")]
        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }
        [Authorize(Policy = "CanEditRooms")]
        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,RoomNumber,Adults,Children")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            return View(room);
        }
        [Authorize(Policy = "CanEditRooms")]
        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
        [Authorize(Policy = "CanEditRooms")]
        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomId == id);
        }
    }
}
