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

        [HttpGet("todas")]
        public async Task<List<Cities>> getAll()
        {

            return await _context.cities.FromSqlRaw("EXEC GetAll").ToListAsync();
        }
        [HttpGet("unico/{id}")]
        public Cities getOne( int id)
        {

            return _context.cities.FromSqlRaw("EXEC GetById {0}", id).AsEnumerable().FirstOrDefault();
            
        }

        [HttpPost("")]
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

        [HttpPost("/{id:int}")]
        public async Task<IActionResult> UpdateCityName([FromRoute]int id, [FromBody] EditNameViewModel cityName)
        {
            var city = getOne(id);
            if(city != null)
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




    }
}
