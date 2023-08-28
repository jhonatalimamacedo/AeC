using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AeCAPI.Entity
{
    public class Cidade
    {
    public int id { get; set; }
    public  string cidade { get; set; }
    public string estado { get; set; }

    public string atualizado_em { get; set; }

        [JsonIgnore]

        public IList<Clima> clima { get; set; } 
    }
}
