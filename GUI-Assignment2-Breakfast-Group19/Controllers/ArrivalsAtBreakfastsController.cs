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
    [Authorize(Policy = "CanViewCheckIn")]
    public class ArrivalsAtBreakfastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArrivalsAtBreakfastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Details));
        }

        // GET: ArrivalsAtBreakfasts
        public async Task<IActionResult> Calendar()
        {
            

            var arrivalList = _context.ArrivalsAtBreakfast.OrderBy(a=>a.Date).ToList();

            return View(arrivalList);
        }
        public async Task<IActionResult> Details(int? id)
        {
            await CheckForData();
            
            ArrivalsAtBreakfast arrivals=null;
            if (id != null) { 
            arrivals =await _context.ArrivalsAtBreakfast
                .Include(a => a.BreakfastAttendees)
                .SingleOrDefaultAsync(a => a.ArrivalsAtBreakfastId==id);
            }
            else//Find today
            {
                arrivals = await _context.ArrivalsAtBreakfast
                    .Include(a=>a.BreakfastAttendees)
                    .SingleOrDefaultAsync(a => a.Date.Date == DateTime.Today.Date);
            }

            if (arrivals == null)
            {
                return NotFound();
            }

            //Get reservations:
            var res = _context.BreakfastReservations
                .Include(r => r.BreakfastReservationList)
                .SingleOrDefault(r => r.Date.Date == arrivals.Date.Date);
            var resNumber = res?.GetNumberOfAdultsAndChildren();
            ArrivalsExtended arrivalsExtended = new ArrivalsExtended(arrivals);
            if (resNumber != null)
            {
                arrivalsExtended.AdultReservations = resNumber[0];
                arrivalsExtended.ChildReservations = resNumber[1];
            }

            return View(arrivalsExtended);
        }

        private async 
        Task
CheckForData()
        {
            var sd = new SeedData(_context);//Seed reservations
            //Check if today exists:
            var todayExists =await _context.ArrivalsAtBreakfast
                .AnyAsync(a => a.Date.Date == DateTime.Today.Date);
            if (todayExists == false)
            {
                var arrivals = new ArrivalsAtBreakfast() { Date = DateTime.Today };
                _context.ArrivalsAtBreakfast.Add(arrivals);
                await _context.SaveChangesAsync();
            }

            //Make a checkin page for each day with reservations
            var reservations =await _context.BreakfastReservations.ToListAsync();
            foreach (var reservation in reservations)
            {
                if (await _context.ArrivalsAtBreakfast
                    .AnyAsync(a =>
                        a.Date.Date == reservation.Date.Date) == false)
                {
                   await _context.AddAsync(new ArrivalsAtBreakfast() { Date = reservation.Date.Date });
                }
            }
            await _context.SaveChangesAsync();
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: BreakfastReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BreakfastReservationsId,Date")] ArrivalsAtBreakfast arrivalsAtBreakfast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrivalsAtBreakfast);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservations = await _context.ArrivalsAtBreakfast
                .FirstOrDefaultAsync(m => m.ArrivalsAtBreakfastId == id);

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
            var arrivals = await _context.ArrivalsAtBreakfast
                .Include(b => b.BreakfastAttendees)
                .FirstOrDefaultAsync(m => m.ArrivalsAtBreakfastId == id);

            foreach (var room in arrivals.BreakfastAttendees)
            {
                _context.Remove(_context.Room.Single(r => r.RoomId == room.RoomId));
            }

            await _context.SaveChangesAsync();

            _context.ArrivalsAtBreakfast.Remove(arrivals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
