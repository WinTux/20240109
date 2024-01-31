using Principal.Models;
using System.ComponentModel.DataAnnotations;

namespace Secundario.Models
{
    public class Detalle
    {
        [Key]
        [Required]
        public int id { get; set; }//de foreign id
        [Required]
        public string nombre_Detalle { get; set; }
        [Required]
        public string descripcion_detalle { get; set; }
        [Required]
        public int platoID { get; set; }//para relacionarse con fid
        public Plato plato { get; set; }//para navegar entre entidades


    }
}
