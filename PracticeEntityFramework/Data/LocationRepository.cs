using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Interface;
using PracticeEntityFramework.Model;

namespace PracticeEntityFramework.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Location>> GetLocationsAsync()
            => await _context.Locations.Take(100).ToListAsync();

        public async Task<Location> GetLocationByIdAsync(short id) 
            => await _context.Locations.FindAsync(id);
        

        public async Task<Location> AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> CreateLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

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

        private bool LocationExists(object locationID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteLocationByIdAsync(int id)
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

        private bool CustomerExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}

