using AeCAPI.Data;
using AeCAPI.Entity;
using AeCAPI.Interface;
using Newtonsoft.Json;

namespace AeCAPI.Service
{
    public class AeroportoService : IAeroportoService
    {
        private readonly AeCContext _context;
        public AeroportoService(AeCContext context)
        {
            _context = context;
        }

        public void create(string message)
        {
            Aeroportos result = JsonConvert.DeserializeObject<Aeroportos>(message);
            _context.aeroporto.Add(result);
            _context.SaveChangesAsync();
        }

        public Aeroportos getId(int id)
        {
            var aeroporto = _context.aeroporto.FirstOrDefault(c => c.id == id);
            return aeroporto;
        }
    }
}
