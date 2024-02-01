using System.ComponentModel.DataAnnotations;

namespace Principal.DTO
{
    public class PlatoPublisherDTO
    {
        
        public string nombre { get; set; }
        public string? ingredientes { get; set; }
        public int precio { get; set; }
        public string tipoEvento { get; set; }
    }
}
