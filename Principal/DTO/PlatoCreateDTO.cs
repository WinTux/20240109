using System.ComponentModel.DataAnnotations;

namespace Principal.DTO
{
    public class PlatoCreateDTO
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int precio { get; set; }
    }
}
