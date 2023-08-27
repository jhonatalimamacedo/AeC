using AeCAPI.Entity;
using AeCAPI.Interface;
using AeCAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly IClimaService _climaService;
        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetClima(int id)
        {
            var result = _climaService.GetClima(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
