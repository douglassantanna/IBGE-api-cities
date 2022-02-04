using System.Collections.Generic;
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
        public async Task<ActionResult<List<City>>> GetCitiesFromDatabase()
        {
            var city = await _dataContext.Cities.ToListAsync();
            return city;
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id)
        {

            if (!ModelState.IsValid) return BadRequest();

            var city = await _dataContext.Cities.FirstOrDefaultAsync(x => x.id == id);

            _dataContext.Cities.Update(city);
            await _dataContext.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ICities>> Delete(string id)
        {
            var city = await _dataContext.Cities.FirstOrDefaultAsync(x => x.id == id);
            if (city is null) { return NotFound(); }

            _dataContext.Remove(city);
            _dataContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            _dataContext.Cities.RemoveRange();
            await _dataContext.SaveChangesAsync();

            return NoContent();

        }
    }
}
