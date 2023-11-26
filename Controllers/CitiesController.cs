using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyingProcedures.Data;
using StudyingProcedures.Models;
using StudyingProcedures.Models.ViewModels;

namespace StudyingProcedures.Controllers
{
    [ApiController]
    [Route("")]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesContext _context;

        public CitiesController(CitiesContext context)
        {
            _context = context;
        }

        [HttpGet("cidades")]
        public async Task<List<Cities>> getAll()
        {

            return await _context.cities.FromSqlRaw("EXEC GetAll").ToListAsync();
        }
        [HttpGet("cidades/{id}")]
        public IActionResult getOne( int id)
        {

            var city =  _context.cities.FromSqlRaw("EXEC GetById {0}", id).AsEnumerable().FirstOrDefault();
            if(city!= null)
            {
                return Ok(new CityViewModel(city.CityName, city.Population));
            }
            return NotFound();
            
        }

        [HttpPost("cidades")]
        public async Task<IActionResult> CreateCity([FromBody] Cities city) 
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("EXEC CreateCity {0},{1}", city.CityName, city.Population);
                await _context.SaveChangesAsync();
                return Ok(new CityViewModel(city.CityName, city.Population));
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPut("cidades/nome/{id:int}")]
        public async Task<IActionResult> UpdateCity([FromRoute]int id, [FromBody] EditNameViewModel cityName)
        {
            var city = _context.cities.FromSqlRaw("EXEC GetById {0}", id).AsEnumerable().FirstOrDefault();
            if (city != null)
            {
                _context.Database.ExecuteSqlRaw("EXEC UpdateCityName {0},{1}", id, cityName.CityName);
                await _context.SaveChangesAsync();
                return Ok(new CityViewModel(cityName.CityName, city.Population));
            }
            else
            {
                return NotFound();
            }             
        }


        [HttpPut("cidades/populacao/{id:int}")]
        public async Task<IActionResult> UpdateCity([FromRoute] int id, [FromBody] EditPopulationViewModel cityPopulation)
        {
            var city = _context.cities.FromSqlRaw("EXEC GetById {0}", id).AsEnumerable().FirstOrDefault();
            if (city != null)
            {
                _context.Database.ExecuteSqlRaw("EXEC UpdatePopulation {0},{1}", id, cityPopulation.Population);
                await _context.SaveChangesAsync();

                return Ok(new CityViewModel(city.CityName, cityPopulation.Population));
            }
            else
            {
                return NotFound();
            }
        }
        





    }
}
