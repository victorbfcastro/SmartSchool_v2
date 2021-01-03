using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoDisciplinaController : ControllerBase
    {
        public AlunoDisciplinaController()
        {
            
        }

        [HttpGet]
        public IActionResult Get ()
        {
            return Ok("Alunos: Teste, teste2");
        }
    }
}