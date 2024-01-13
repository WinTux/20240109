using System.ComponentModel.DataAnnotations;

namespace Principal.DTO
{
    public class PlatoUpdateDTO
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string? ingredientes { get; set; }
        [Required]
        public int precio { get; set; }
    }
}
