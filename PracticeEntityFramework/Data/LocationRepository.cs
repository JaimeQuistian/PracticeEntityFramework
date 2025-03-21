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
    }
}

