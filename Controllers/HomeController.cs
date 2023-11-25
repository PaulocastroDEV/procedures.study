using Microsoft.AspNetCore.Mvc;

namespace StudyingProcedures.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            return StatusCode(200, "Ta funcionando as rotas");
        }
    }
}
