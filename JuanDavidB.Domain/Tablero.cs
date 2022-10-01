using System.ComponentModel.DataAnnotations;

namespace JuanDavidB.Domain
{
    public class Tablero
    {
        public int Id { get; set; }
        [Required]
        public string Deportista { get; set; }
        [MaxLength(3)] public string Pais { get; set; }
        [Required]
        public int Arranque { get; set; }
        [Required]
        public int Envion { get; set; }
        [Required]
        public int TotalPeso { get; set; }
    }
}