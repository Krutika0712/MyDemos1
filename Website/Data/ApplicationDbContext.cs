using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Website.Models.LoanCategory> LoanCategory { get; set; }
        public DbSet<Website.Models.Customer> Customer { get; set; }

       
    }
}
