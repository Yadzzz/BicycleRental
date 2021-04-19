using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BicycleRental.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleRental.Data
{
    public class BikeShopContext : DbContext
    {
        public DbSet<Bicycles> Bicycles { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Bookings_Items> Bookings_Items { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SK1M2S4\\MSSQLSERVER01;Initial Catalog=BikeShopTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
