using System.Threading.Tasks;
using Cities;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("municipios")]
    public class CityController : ControllerBase 
    {
        ICities _cities;
        public CityController(ICities cities)
        {   
            _cities = cities;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _cities.Get());
        }
    }
}
