using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyingProcedures.Data;
using StudyingProcedures.Models;

namespace StudyingProcedures.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly CitiesContext _context;

        public HomeController(CitiesContext context)
        {
            _context = context;
        }

        [HttpGet("todas")]
        public async Task<List<Cities>> getAll()
        {

            return await _context.cities.FromSqlRaw("EXEC GetAll").ToListAsync();
        }


    }
}
