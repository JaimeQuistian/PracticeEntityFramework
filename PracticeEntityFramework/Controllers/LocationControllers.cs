using Microsoft.AspNetCore.Mvc;
using PracticeEntityFramework.Interface;
using PracticeEntityFramework.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationById(short id)
        {
            var customer = await _locationRepository.GetLocationByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = await _locationRepository.GetLocationsAsync();
            return Ok(locations);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> CreateLocation(Location location)
        {
            var createdLocation = await _locationRepository.CreateLocationAsync(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = createdLocation.LocationId }, createdLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(short id, Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }

            var result = await _locationRepository.UpdateLocationAsync(location);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(short id)
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
