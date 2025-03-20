using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Interface;
using PracticeEntityFramework.Model;
using System;

namespace PracticeEntityFramework.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Location> GetLocationAsync(short id) => await _context.Location.FindAsync(id);
        public async Task<IEnumerable<Location>> GetLocationsAsync() => await _context.Location.Take(100).ToListAsync();

        public async Task<Location> CreateCustomerAsync(Location location)
        {
            _context.Location.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }
    }

    public interface ICustomerRepository
    {
    }
}

