using AeCAPI.Data;
using AeCAPI.Entity;
using AeCAPI.Interface;
using Newtonsoft.Json;

namespace AeCAPI.Service
{
    public class CidadeService : ICidadeService
    {
        private readonly AeCContext _context;
        public CidadeService(AeCContext aeCContext)
        {
            _context = aeCContext;
        }
        public  void create(string message)
        {
            var result = JsonConvert.DeserializeObject<Cidades>(message);

            Cidades cidade = new Cidades
            {
                cidade = result.cidade,
                atualizado_em = result.atualizado_em,
                estado = result.estado,

            };
            _context.cidades.Add(cidade);
            _context.SaveChangesAsync();

            foreach (var item in result.clima)
            {
                Clima clima = new Clima
                {
                    condicao = item.condicao,
                    condicao_desc = item.condicao_desc,
                    data = item.data,
                    indice_uv = item.indice_uv,
                    max = item.max,
                    min = item.min,
                    idCidade = cidade.id
                };
                _context.climas.Add(clima);
            }
             _context.SaveChanges();
        }

        public Cidades getId(int id)
        {

            var cidade = _context.cidades.FirstOrDefault(c => c.id == id);
            return cidade;
        }
    }

}
