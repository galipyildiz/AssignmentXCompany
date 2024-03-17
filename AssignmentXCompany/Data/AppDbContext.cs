using AssignmentXCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentXCompany.Data
{
    public class AppDbContext : DbContext
    {
        //Task 3.1
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
