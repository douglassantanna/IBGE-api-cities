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
        [Route("{id}")]

        public async Task<ActionResult<List<City>>> GetCitiesFromDatabaseById(string id)
        {
            var city = await _dataContext.Cities.FirstOrDefaultAsync(x => x.id == id);
            return Ok();
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

        [HttpPut]
        [Route("{id}")]

        public ActionResult Update(string id, UpdateUser updateUser)
        {
            var city = _dataContext.Cities.FirstOrDefault(x => x.id == id);
            if (city is null) return NotFound();

            city.UpdateName(updateUser.nome);
            _dataContext.Entry(city).State = EntityState.Modified;
            _dataContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
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
            var cities = await _dataContext.Cities.ToListAsync();
            foreach (var city in cities)
            {
                _dataContext.Cities.Remove(city);
            }
            await _dataContext.SaveChangesAsync();
            return NoContent();

        }

        public record UpdateUser(string nome);
    }
}
