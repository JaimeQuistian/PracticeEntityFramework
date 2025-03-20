using PracticeEntityFramework.Model;

namespace PracticeEntityFramework.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
    }
}
