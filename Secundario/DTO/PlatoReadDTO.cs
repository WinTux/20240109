using System.ComponentModel.DataAnnotations;

namespace Secundario.DTO
{
    public class PlatoReadDTO
    {
        //public int id { get; set; }//de foreign id
        
        
        public string nombre { get; set; }
        public string? ingredientes { get; set; }
        
        public int precio { get; set; }
    }
}
