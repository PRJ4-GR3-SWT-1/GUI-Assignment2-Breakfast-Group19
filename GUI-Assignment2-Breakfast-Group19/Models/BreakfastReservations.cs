﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Assignment2_Breakfast_Group19.Models
{
    public class BreakfastReservations
    {
        public int BreakfastReservationsId { get; set; }
        public DateTime Date { get; set; }
        public List<Room> BreakfastReservationList { get; set; }
    }
}