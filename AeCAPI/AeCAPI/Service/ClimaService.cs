using AeCAPI.Data;
using AeCAPI.Entity;
using AeCAPI.Interface;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AeCAPI.Service
{
    public class ClimaService : IClimaService
    {
        private readonly AeCContext _context;
        public ClimaService(AeCContext context)
        {
            _context = context;
        }
        public Clima GetClima(int id)
        {
            var result = _context.climas.FirstOrDefault(i => i.id == id);
            return result;
        }
    }
}
