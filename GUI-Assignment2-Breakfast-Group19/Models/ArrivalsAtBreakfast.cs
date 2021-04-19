using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Assignment2_Breakfast_Group19.Models
{
    public class ArrivalsAtBreakfast
    {
        private int ArrivalsAtBreakfastId { get; set; }
        public DateTime Date { get; set; }
        public List<Room> BreakfastAttendees { get; set; }
    }
}
