using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Assignment2_Breakfast_Group19.Models
{
    public class Room
    {
        public Room() { }
        public Room(int rn, int adults, int children)
        {
            RoomNumber = rn;
            Adults = adults;
            Children = children;
        }


        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
    }
    //Transfer object used for creating reservation
    public class RoomExtended : Room
    {
        public DateTime date { get; set; }
    }
}
