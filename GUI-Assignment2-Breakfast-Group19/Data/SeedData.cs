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

        private void SeedRoomRandomAdultAndChildren(int roomnumber, ApplicationDbContext dbContext)
        {
            Random rand = new Random();
            int adults = rand.Next(1, 4);
            int children = rand.Next(4);

            Room r = new Room(roomnumber, adults, children);
            dbContext.Add(r);

        }



        private void SeedFirstDay(ApplicationDbContext dbContext)
        {
            for (int i = 1;i < 5; i++)
            {
                SeedRoomRandomAdultAndChildren(i,dbContext);
            }
        }

        private void SeedSecondDay(ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        private void SeedThirdDay(ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        private void SeedFourthDay(ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        private void SeedFifthDay(ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        private void SeedSixthDay(ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        private void SeedSeventhDay(ApplicationDbContext dbContext)
        {
            
        }
    }
}
