using AeCAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AeroporotController : ControllerBase
    {
        private readonly IAeroportoService _aeroporto;

        public AeroporotController(IAeroportoService aeroporto)
        {
            _aeroporto = aeroporto;
        }

        [HttpGet]
        public IActionResult GetAeroporto(int id)
        {
            var result = _aeroporto.GetById(id);

            if (result == null)
            {
                return NotFound(); // Retorna 404 caso o aeroporto não seja encontrado
            }

            return Ok(result); // Retorna 200 com o aeroporto encontrado
        }
    }
}
