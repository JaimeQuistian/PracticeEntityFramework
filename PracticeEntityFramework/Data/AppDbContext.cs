using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Model;


namespace PracticeEntityFramework.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // Agrega aqui los DbSet de las tablas que usarás
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura el esquema y el nombre de la tabla
            modelBuilder.Entity<Location>().ToTable("Location",schema: "Production");
        }
        public DbSet<Location> Locations { get; set; }
    
    }
}
