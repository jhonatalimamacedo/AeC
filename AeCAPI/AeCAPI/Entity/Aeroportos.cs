
using System.ComponentModel.DataAnnotations;

namespace AeCAPI.Entity
{
    public class Aeroportos
    {
        public int id { get; set; }
        public int umidade { get; set; }
        public string visibilidade { get; set; }
        public string codigo_icao { get; set; }
        public int pressao_atmosferica { get; set; }
        public int vento { get; set; }
        public int direcao_vento { get; set; }
        public string condicao { get; set; }
        public string condicao_desc { get; set; }
        public int temp { get; set; }
        public string atualizado_em { get; set; }
        
        
    }
}
