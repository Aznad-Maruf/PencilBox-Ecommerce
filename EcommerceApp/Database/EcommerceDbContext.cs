using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Database
{
    public class EcommerceDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = @"Server=ROBINHOOD\MARUFROBINSQL; Database=EcommerceDb6; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
