using ABCTask.DTO;
using ABCTask.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ABCTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCity()
        {
            var model = await _cityRepository.GetAllCities();
            return Ok(model);
        }
    }
}
