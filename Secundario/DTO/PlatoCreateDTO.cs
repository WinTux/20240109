using System.ComponentModel.DataAnnotations;

namespace Secundario.DTO
{
    public class DetalleCreateDTO
    {
        [Required]
        public int id { get; set; }//de foreign id
        [Required]
        public string nombre_Detalle { get; set; }
        [Required]
        public string descripcion_detalle { get; set; }
    }
}
