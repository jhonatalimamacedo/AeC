using AeCAPI.Interface;
using AeCAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CptecController : ControllerBase
    {
        private readonly ILogger<CptecController> _logger; 
        private readonly ICptecService _climaService;
        private readonly ICidadeService _cidada;
        private readonly IAeroportoService _aeroporto;
        private readonly ILogService _logService;

        public CptecController(ICptecService climaService, ICidadeService cidada, IAeroportoService aeroporto, ILogger<CptecController> logger, ILogService logService)
        {
            _climaService = climaService;
            _cidada = cidada;
            _aeroporto = aeroporto;
            _logger = logger;
            _logService = logService;
        }

        [HttpGet]
        [Route("cidade")]
        public async Task<IActionResult> GetCidade(int codigo)
        {

            try
            {
                _logger.LogInformation("Received GET request for GetCidade with code: {Codigo}", codigo);
                var result = await _climaService.cidade(codigo);

                _cidada.Create(result);
               // _logService.SaveLog(200, "Successfully retrieved and saved city data");
                return Content(result, "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetCidade action: {ErrorMessage}", ex.Message);
               // _logService.SaveLog(404, "Error occurred in GetCidade action: " + ex.Message);
                return StatusCode(404, ex.Message);
            }

        }
        [HttpGet]
        [Route("aeroporto")]
        public async Task<IActionResult> GetAeroPorto(string codigo)
        {
            try
            {
                var result = await _climaService.aeroporto(codigo);
                _logger.LogInformation("Received GET request for GetCidade with code: {Codigo}", codigo);
                _aeroporto.Create(result);
               // _logService.SaveLog(200, "Successfully retrieved and saved city data");
                return Content(result, "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetCidade action: {ErrorMessage}", ex.Message);
               // _logService.SaveLog(404, "Error occurred in GetCidade action: " + ex.Message);
                return StatusCode(404, ex.Message);
            }

        }
    }
}
