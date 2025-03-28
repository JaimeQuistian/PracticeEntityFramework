
using PracticeEntityFramework.Model;

namespace PracticeEntityFramework.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        //
        Task<Location> GetLocationByIdAsync(short id);
        Task<Location> AddLocationAsync(Location location);

        Task<Location> CreateLocationAsync(Location location);
        Task<bool> UpdateLocationAsync(Location location);
        Task<bool> DeleteLocationByIdAsync(short id);

    }
}
