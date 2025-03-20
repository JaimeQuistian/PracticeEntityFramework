using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Model;


namespace PracticeEntityFramework.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
           public DbSet<Location> Location { get; set; }
    
    }
}
