using PracticeEntityFramework.Model;

namespace PracticeEntityFramework.Interface
{
    /*
        Definir los métodos que la clase "LocationRepository" implementará. 
    */
    public interface ILocationRepository
    {
        // Obtener todas las ubicaciones
        Task<IEnumerable<Location>> GetLocationsAsync();
        // Obtener una ubicación por su ID
        Task<Location> GetLocationByIdAsync(short id);
        // Crear una nueva ubicación
        Task<Location> CreateLocationAsync(Location location);
        // Actualizar una ubicación
        Task<bool> UpdateLocationAsync(Location location);
        // Eliminar una ubicación por su ID
        Task<bool> DeleteLocationByIdAsync(short id);

    }
}
