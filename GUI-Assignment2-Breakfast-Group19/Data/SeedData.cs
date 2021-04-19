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
                SeedFirstDay(dbContext);
                SeedSecondDay(dbContext);
                SeedThirdDay(dbContext);
                SeedFourthDay(dbContext);
                SeedFifthDay(dbContext);
                SeedSixthDay(dbContext);
                SeedSeventhDay(dbContext);
            }
        }

        private Room SeedRoomRandomAdultAndChildren(int roomnumber, ApplicationDbContext dbContext)
        {
            Random rand = new Random();
            int adults = rand.Next(1, 4);
            int children = rand.Next(4);

            Room r = new Room(roomnumber, adults, children);
            dbContext.Add(r);
            return r;
        }



        private void SeedFirstDay(ApplicationDbContext dbContext)
        {
            for (int i = 1;i < 5; i++)
            {
                Room r = SeedRoomRandomAdultAndChildren(i,dbContext);
                if ((i % 2) == 1)
                {
                    BreakfastReservations br = new BreakfastReservations(r, DateTime.Now);
                    dbContext.BreakfastReservations.Add(br);
                }
            }
        }

        private void SeedSecondDay(ApplicationDbContext dbContext)
        {
            for (int i = 1; i < 5; i++)
            {
                Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
                if ((i % 2) == 1)
                {
                    BreakfastReservations br = new BreakfastReservations(r, DateTime.Now.AddDays(1));
                    dbContext.BreakfastReservations.Add(br);
                }
            }
        }

        private void SeedThirdDay(ApplicationDbContext dbContext)
        {
            for (int i = 1; i < 5; i++)
            {
                Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
                if ((i % 2) == 1)
                {
                    BreakfastReservations br = new BreakfastReservations(r, DateTime.Now.AddDays(2));
                    dbContext.BreakfastReservations.Add(br);
                }
            }
        }

        private void SeedFourthDay(ApplicationDbContext dbContext)
        {
            for (int i = 1; i < 5; i++)
            {
                Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
                if ((i % 2) == 1)
                {
                    BreakfastReservations br = new BreakfastReservations(r, DateTime.Now.AddDays(3));
                    dbContext.BreakfastReservations.Add(br);
                }
            }
        }

        private void SeedFifthDay(ApplicationDbContext dbContext)
        {
            for (int i = 1; i < 5; i++)
            {
                Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
                if ((i % 2) == 1)
                {
                    BreakfastReservations br = new BreakfastReservations(r, DateTime.Now.AddDays(4));
                    dbContext.BreakfastReservations.Add(br);
                }
            }
        }

        private void SeedSixthDay(ApplicationDbContext dbContext)
        {
            for (int i = 1; i < 5; i++)
            {
                Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
                if ((i % 2) == 1)
                {
                    BreakfastReservations br = new BreakfastReservations(r, DateTime.Now.AddDays(5));
                    dbContext.BreakfastReservations.Add(br);
                }
            }
        }

        private void SeedSeventhDay(ApplicationDbContext dbContext)
        {
            for (int i = 1; i < 5; i++)
            {
                Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
                if ((i % 2) == 1)
                {
                    BreakfastReservations br = new BreakfastReservations(r, DateTime.Now.AddDays(6));
                    dbContext.BreakfastReservations.Add(br);
                }
            }
        }
    }
}
