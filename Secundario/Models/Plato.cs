using Secundario.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Principal.Models
{
    public class Plato
    {
        [Key]
        [Required]
        public int id {  get; set; }//de foreign id
        [Required]
        public int fid { get; set; }//de foreign id
        [Required]
        public string nombre { get; set; }
        public string? ingredientes { get; set; }
        [Required]
        public int precio { get; set; }

        public ICollection<Detalle> detalles { get; set; } = new List<Detalle>();
    }
}
