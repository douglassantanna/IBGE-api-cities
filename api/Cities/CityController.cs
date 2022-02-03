using System.Threading.Tasks;
using Cities;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("municipios")]
    public class CityController : ControllerBase
    {
        ICities _cities;
        DataContext _dataContext;
        public CityController(ICities cities, DataContext dataContext)
        {
            _cities = cities;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _cities.GetCities());
        }

        [HttpPost]
        public async Task<dynamic> PopulateDatabase()
        {
            var cities = await _cities.GetCities();

            foreach (var city in cities)
            {
                _dataContext.Cities.Add(city);
            }
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
