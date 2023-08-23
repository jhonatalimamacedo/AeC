using AeCAPI.Entity;
using AeCAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AeroporotController : ControllerBase
    {
        private readonly IAeroportoService _aeroporto;
        public AeroporotController( IAeroportoService aeroportos)
        {
            _aeroporto = aeroportos;
        }
        [HttpGet]
        public Aeroportos getAeroporto(int id)
        {

            var result = _aeroporto.getId(id);
            return result;

        }
    }
}
