using AeCAPI.Interface;
using AeCAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _logService.Get();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
