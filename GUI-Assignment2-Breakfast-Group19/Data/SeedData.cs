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
                Seed7Day(dbContext);
                //SeedSecondDay(dbContext);
                //SeedThirdDay(dbContext);
                //SeedFourthDay(dbContext);
                //SeedFifthDay(dbContext);
                //SeedSixthDay(dbContext);
                //SeedSeventhDay(dbContext);
            }
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

        //private void SeedSecondDay(ApplicationDbContext dbContext)
        //{
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
        //        if ((i % 2) == 1)
        //        {
        //            BreakfastReservations br = new BreakfastReservations(r, DateTime.Today.AddDays(1));
        //            dbContext.BreakfastReservations.Add(br);
        //        }
        //    }
        //}

        //private void SeedThirdDay(ApplicationDbContext dbContext)
        //{
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
        //        if ((i % 2) == 1)
        //        {
        //            BreakfastReservations br = new BreakfastReservations(r, DateTime.Today.AddDays(2));
        //            dbContext.BreakfastReservations.Add(br);
        //        }
        //    }
        //}

        //private void SeedFourthDay(ApplicationDbContext dbContext)
        //{
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
        //        if ((i % 2) == 1)
        //        {
        //            BreakfastReservations br = new BreakfastReservations(r, DateTime.Today.AddDays(3));
        //            dbContext.BreakfastReservations.Add(br);
        //        }
        //    }
        //}

        //private void SeedFifthDay(ApplicationDbContext dbContext)
        //{
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
        //        if ((i % 2) == 1)
        //        {
        //            BreakfastReservations br = new BreakfastReservations(r, DateTime.Today.AddDays(4));
        //            dbContext.BreakfastReservations.Add(br);
        //        }
        //    }
        //}

        //private void SeedSixthDay(ApplicationDbContext dbContext)
        //{
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
        //        if ((i % 2) == 1)
        //        {
        //            BreakfastReservations br = new BreakfastReservations(r, DateTime.Today.AddDays(5));
        //            dbContext.BreakfastReservations.Add(br);
        //        }
        //    }
        //}

        //private void SeedSeventhDay(ApplicationDbContext dbContext)
        //{
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Room r = SeedRoomRandomAdultAndChildren(i, dbContext);
        //        if ((i % 2) == 1)
        //        {
        //            BreakfastReservations br = new BreakfastReservations(r, DateTime.Today.AddDays(6));
        //            dbContext.BreakfastReservations.Add(br);
        //        }
        //    }
        //}
    }
}
