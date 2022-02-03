using System.Linq;
using System.Threading.Tasks;
using Cities;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // [HttpPut("{id}")]
        // public async Task<ActionResult> Update(string id, UpdateCity updateCity){

        // }
        [HttpDelete("id")]
        public ActionResult Delete(string id)
        {
            var city =  _dataContext.Cities.FirstOrDefault(x => x.id == id);

            if (city is null) { return NotFound(); }

            _dataContext.Remove(city);
            _dataContext.SaveChanges();
            return NoContent();
        }

        public record UpdateCity(string id, string nome);
    }
}
