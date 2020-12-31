using ABCTask.Core;
using ABCTask.DTO;
using ABCTask.DTO.FluentValidator;
using ABCTask.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABCTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IList<LocationDTO>>> GetLocation() //get all location
        {

            var model = await _locationRepository.GetAllLocation();
            return Ok(model);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetLocation(int id) //get 1 location
        {
            var location = await _locationRepository.GetLocationById(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTOPUT>> GetLocationCityId(int id) //get 1 location
        {
            var location = await _locationRepository.GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, LocationDTOPUT location)
        {
            LocationValidatorPut validator = new LocationValidatorPut();
            await validator.ValidateAndThrowAsync(location);
            if (id != location.Id)
            {
                return BadRequest();
            }

            try
            {
                await _locationRepository.ModifyEntity(location);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _locationRepository.LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LocationDTOPost>> PostLocation(LocationDTOPost location)
        {
            LocationValidator validator = new LocationValidator();
            await validator.ValidateAndThrowAsync(location);

            return await _locationRepository.CreateLocation(location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationDTO>> DeleteLocation(int id)
        {
            var location = await _locationRepository.GetById(id);
            if (location == null)
            {
                return NotFound();
            }

            await _locationRepository.Delete(id);
            await _locationRepository.Commit();

            return Ok();
        }
    }
}
