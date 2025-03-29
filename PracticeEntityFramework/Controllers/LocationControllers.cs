using Microsoft.AspNetCore.Mvc;
using PracticeEntityFramework.Interface;
using PracticeEntityFramework.Model;
/*
    Definir los endpoints de la API para manejar las ubicaciones. 
*/
namespace PracticeEntityFramework.Controllers
{
    // Ruta de la API
    [Route("api/[controller]")]
    // Controlador de la API
    [ApiController]
    public class LocationController : ControllerBase
    {
        // Repositorio de ubicaciones
        private readonly ILocationRepository _locationRepository; // Declarar "_locationRepository" como solo lectura

        // Constructor
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // Obtener una ubicación por su ID
        [HttpGet("{id}")] // Petición HttpGet (Las obtiene por medio de su id)
        // Método asincrónico que retorna una ubicación por su ID (asincrono es una operación que no bloquea el hilo de ejecución)
        public async Task<ActionResult<Location>> GetLocationById(short id)
        {
            // Declarar "customer" como una variable local que almacena la ubicación obtenida por su ID, await _locationRepository.GetLocationByIdAsync(id) es una operación asincrónica
            var customer = await _locationRepository.GetLocationByIdAsync(id);
            // Si la ubicación no existe, retorna un NotFound
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // Obtener todas las ubicaciones
        [HttpGet] // Petición HttpGet
        // Método asincrónico que retorna una lista de ubicaciones
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations() // Retorna una lista de ubicaciones, IEnumerable es una interfaz que permite recorrer una colección de elementos
        {
            // Declarar "locations" como una variable local que almacena la lista de ubicaciones
            var locations = await _locationRepository.GetLocationsAsync();
            // Devuelve la lista de ubicaciones (El objeto Ok crea un objeto de respuesta HTTP 200) HTTP 200 es el código de estado de respuesta HTTP que indica que la solicitud ha tenido éxito
            return Ok(locations);
        }

        // Crear una nueva ubicación
        [HttpPost] // Petición HttpPost
        // Método asincrónico que crea una nueva ubicación
        public async Task<ActionResult<Location>> CreateLocation(Location location) // Crea una nueva ubicación
        {
            // Declarar "createdLocation" como una variable local que almacena la ubicación creada
            var createdLocation = await _locationRepository.CreateLocationAsync(location);
            // Retorna la ubicación creada (El objeto CreatedAtAction crea un objeto de respuesta HTTP 201) HTTP 201 es el código de estado de respuesta HTTP que indica que se ha creado un nuevo recurso
            return CreatedAtAction(nameof(GetLocationById), new { id = createdLocation.LocationId }, createdLocation);
        }

        // Actualizar una ubicación
        [HttpPut("{id}")] // Petición HttpPut (Actualiza una ubicación por su ID)
        // Método asincrónico que actualiza una ubicación
        public async Task<IActionResult> UpdateLocation(short id, Location location) // Actualiza una ubicación
        {
            // Si el ID no coincide con la ubicación, retorna un BadRequest 
            if (id != location.LocationId)
            {
                //BadRequest es un código de estado de respuesta HTTP que indica que la solicitud no pudo ser procesada debido a un error del cliente
                return BadRequest();
            }
            // Declarar "result" como una variable local que almacena el resultado de la actualización de la ubicación
            var result = await _locationRepository.UpdateLocationAsync(location);
            // Si la ubicación no existe, retorna un NotFound
            if (!result)
            {
                // NotFound es un código de estado de respuesta HTTP que indica que el recurso solicitado no se encuentra disponible
                return NotFound();
            }
            // Retorna un NoContent (El objeto NoContent crea un objeto de respuesta HTTP 204) HTTP 204 es el código de estado de respuesta HTTP que indica que la solicitud se ha completado con éxito pero no devuelve ningún contenido
            return NoContent();
        }

        // Eliminar una ubicación
        [HttpDelete("{id}")] // Petición HttpDelete (Elimina una ubicación por su ID)
        // Método asincrónico que elimina una ubicación
        public async Task<IActionResult> DeleteLocation(short id) // Elimina una ubicación IActionResult es una interfaz que representa el resultado de una acción
        {
            var result = await _locationRepository.DeleteLocationByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
