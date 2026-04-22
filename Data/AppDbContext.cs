using Microsoft.EntityFrameworkCore;
using LiftingApp.Models;

namespace LiftingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
    }
}