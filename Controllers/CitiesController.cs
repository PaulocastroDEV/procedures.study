using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyingProcedures.Data;
using StudyingProcedures.Models;

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
        


    }
}
