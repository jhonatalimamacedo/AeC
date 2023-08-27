using AeCAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AeroportosClimaController : ControllerBase
    {
        private readonly IAeroportoService _aeroporto;

        public AeroportosClimaController(IAeroportoService aeroporto)
        {
            _aeroporto = aeroporto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAeroporto(int id)
        {
            var result = _aeroporto.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}