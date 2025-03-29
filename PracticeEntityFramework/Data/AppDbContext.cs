using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Model;


namespace PracticeEntityFramework.Data
{
    /*
      Gestionar la conexión con la BD permitiendo la manipulación de datos usando 
      Entity Framework Core.
    */
    public class AppDbContext:DbContext
    {
        // Permite interactuar con la tabla Location como si fuera una colección en memoria.
        public DbSet<Location> Locations { get; set; }

        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Configura el esquema y el nombre de la tabla
        // Agrega aqui los DbSet de las tablas que usarás

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura el esquema y el nombre de la tabla
            modelBuilder.Entity<Location>().ToTable("Location", schema: "Production");
        }

    }
}
