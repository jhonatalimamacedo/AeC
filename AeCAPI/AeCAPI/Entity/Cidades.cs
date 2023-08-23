using System.ComponentModel.DataAnnotations;

namespace AeCAPI.Entity
{
    public class Cidades
    {
    [Key]
    public int id { get; set; }
    public  string cidade { get; set; }
    public string estado { get; set; }

    public string atualizado_em { get; set; }

    public IList<Clima> clima { get; set; } 
    }
}
