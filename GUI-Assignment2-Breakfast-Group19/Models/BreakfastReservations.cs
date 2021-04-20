using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Assignment2_Breakfast_Group19.Models
{
    public class BreakfastReservations
    {
        public BreakfastReservations()
        {
            BreakfastReservationList = new List<Room>();
        }
        public BreakfastReservations( DateTime now)
        {
            BreakfastReservationList = new List<Room>();
            Date = now;
        }
        public int BreakfastReservationsId { get; set; }
        public DateTime Date { get; set; }
        public List<Room> BreakfastReservationList { get; set; }

        public int[] GetNumberOfAdultsAndChildren()
        {
            int child = 0;
            int adult = 0;
            foreach (var reservation in BreakfastReservationList)
            {
                child += reservation.Children;
                adult += reservation.Adults;
            }
            return new int[2]{ adult,child}
            ;
        }
    }
}
