using Microsoft.EntityFrameworkCore;
using ParkyApplication.Models;

namespace ParkyApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<NationalParkModel> NationalParks { get; set; }
    }
}
