using System.ComponentModel.DataAnnotations;

namespace Secundario.DTO
{
    public class DetalleReadDTO
    {
        public int id { get; set; }//de foreign id
        
        public string nombre_Detalle { get; set; }
        
        public string descripcion_detalle { get; set; }
        public int platoID { get; set; }
    }
}
