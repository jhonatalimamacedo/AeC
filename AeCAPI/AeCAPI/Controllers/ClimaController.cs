using AeCAPI.Entity;
using AeCAPI.Interface;
using AeCAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly IClimaService _climaService;
        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }
        [HttpGet]
        public Clima GetClima(int id)
        {
            var result = _climaService.GetClima(id);
            return result;
        }
    }
}
