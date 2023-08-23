using System.ComponentModel.DataAnnotations;

namespace AeCAPI.Entity
{
    public class log
    {
        [Key]
        public int id { get; set; }
        public DateTime data { get; set; }
        public int codeMessage { get; set; }
        public string message { get; set; }
    }
}
