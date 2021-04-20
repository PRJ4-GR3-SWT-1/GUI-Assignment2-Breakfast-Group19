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
    public class ArrivalsAtBreakfastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArrivalsAtBreakfastsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Policy= "CanCheckInGuests")]
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
    }
}
