using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUI_Assignment2_Breakfast_Group19.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace GUI_Assignment2_Breakfast_Group19.Data
{
    public class SeedData
    {

        public SeedData(ApplicationDbContext dbContext)
        {
            var r = dbContext.Room.FirstOrDefault();
            if (r == null)
            {
              
                
                SeedArrivals(dbContext);
            }
        }

        private void SeedArrivals(ApplicationDbContext dbContext)
        {
            var arrivals = new ArrivalsAtBreakfast();
            for (int i = 0; i < 4; i++)
            {
                arrivals.BreakfastAttendees.Add(new Room(i+100, i + 1, i * 2));
            }

            dbContext.Add(arrivals);
            dbContext.SaveChanges();

        }

        private Room SeedRoomRandomAdultAndChildren(int roomnumber, ApplicationDbContext dbContext)
        {
            Random rand = new Random();
            int adults = rand.Next(1, 4);
            int children = rand.Next(4);

            Room r = new Room(roomnumber, adults, children);
           // dbContext.Add(r);
            return r;
        }



        private void Seed7Day(ApplicationDbContext dbContext)
        {
            for (int day = 0; day < 6; day++)
            {
                
                BreakfastReservations br = new BreakfastReservations(DateTime.Today.AddDays(day));
                for (int i = 1;i < 5; i++)
                {
                    Room r = SeedRoomRandomAdultAndChildren(i,dbContext);
                    if ((i % 2) == 1)
                    {

                        br.BreakfastReservationList.Add(r);

                    }
                }
                dbContext.BreakfastReservations.Add(br);
            }

            dbContext.SaveChanges();
        }
        
    }
}
