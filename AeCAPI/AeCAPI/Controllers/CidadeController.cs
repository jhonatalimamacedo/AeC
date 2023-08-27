using AeCAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;
        public CidadeController(ICidadeService cidades)
        {
            _cidadeService = cidades;
        }
        [HttpGet]
        public async Task<IActionResult> getCidade(int id)
        {

            var result = _cidadeService.GetById(id);

            if (result == null)
            {
                return NotFound(); // Retorna 404 caso o aeroporto não seja encontrado
            }

            return Ok(result); // Retorna 200 com o aeroporto encontrado

        }

    }
}
