using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Database.Database
{
    public class EcommerceDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = @"Server=(local); Database=EcommerceDb6; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
