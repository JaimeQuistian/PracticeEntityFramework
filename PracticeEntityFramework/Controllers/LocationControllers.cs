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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = await _locationRepository.GetLocationsAsync();
            return Ok(locations);
        }
    }
}
