using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Principal.Models
{
    [Table("Plato")]
    public class Plato
    {
        [Key]
        [Required]
        public int id {  get; set; }
        [Required]
        public string nombre { get; set; }
        public string ingredientes { get; set; }
        [Required]
        public int precio { get; set; }
    }
}
