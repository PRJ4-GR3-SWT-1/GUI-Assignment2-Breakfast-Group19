using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GUI_Assignment2_Breakfast_Group19.Models;

namespace GUI_Assignment2_Breakfast_Group19.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<ArrivalsAtBreakfast> ArrivalsAtBreakfast { get; set; }
        public DbSet<GUI_Assignment2_Breakfast_Group19.Models.BreakfastReservations> BreakfastReservations { get; set; }
    }
}
