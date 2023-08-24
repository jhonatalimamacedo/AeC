
namespace AeCAPI.Model
{
    public class ClimaModel
    {
        public int id { get; set; }
        public string data { get; set; }
        public string condicao { get; set; }
        public string condicao_desc { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int indice_uv { get; set; }
        public int idCidade { get; set; }
    }
}
