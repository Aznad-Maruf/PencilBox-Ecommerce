using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Database.Database
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
