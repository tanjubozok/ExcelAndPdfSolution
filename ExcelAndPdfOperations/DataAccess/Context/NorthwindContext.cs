using ExcelAndPdfOperations.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelAndPdfOperations.DataAccess.Context
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Northwind;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Products> Products { get; set; }
    }
}
