using System.ComponentModel.DataAnnotations;

namespace Principal.DTO
{
    public class PlatoReadDTO
    {
        public string nombre { get; set; }
        public string ingredientes { get; set; }
        public int precio { get; set; }
    }
}
