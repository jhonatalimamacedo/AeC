using System.ComponentModel.DataAnnotations;

namespace AeCAPI.Entity
{
    public class log
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public int codeMessage { get; set; }
        public string messagem { get; set; }
    }
}
