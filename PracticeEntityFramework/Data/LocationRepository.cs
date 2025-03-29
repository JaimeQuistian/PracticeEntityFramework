using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Interface;
using PracticeEntityFramework.Model;

namespace PracticeEntityFramework.Data
{
    /*
        Implementar las operaciones CRUD sobre la tabla Location
    */
    public class LocationRepository : ILocationRepository
    {
        // Contexto de la base de datos
        private readonly AppDbContext _context; // Declarar "_context" como solo lectura

        // Constructor
        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener los primeros 100 registros de la tabla Location
        public async Task<IEnumerable<Location>> GetLocationsAsync()
            => await _context.Locations.Take(100).ToListAsync();

        // Obtener una ubicación por su ID
        public async Task<Location> GetLocationByIdAsync(short id)
            => await _context.Locations.FindAsync(id);

        // Crear una nueva ubicación
        public async Task<Location> CreateLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        // Actualizar una ubicación
        public async Task<bool> UpdateLocationAsync(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(location.LocationId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        // Eliminar una ubicación por su ID
        public async Task<bool> DeleteLocationByIdAsync(short id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return false;
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return true;
        }

        // Verificar si una ubicación existe
        private bool LocationExists(short id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }      
    }
}

