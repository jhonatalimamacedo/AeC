using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeCAPI.Entity
{
    public class Clima
    {
       [Key]
       public int id {  get; set; }
       public string data { get; set; }
       public string condicao { get; set; }
       public string condicao_desc { get; set; }
       public int min { get; set; }
       public int max { get; set; }
       public int indice_uv { get; set; }

        [ForeignKey("Cidades")]
        [Column("idCidade")]
        public int idCidade { get; set; }
    }
}
