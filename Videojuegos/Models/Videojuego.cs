using System.ComponentModel.DataAnnotations;

namespace Videojuegos.Models
{
    public class Videojuego
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 35 caracteres")]
        public required string NameVG { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un género")]
        public required string Genre { get; set; }
        
        [Required(ErrorMessage = "El desarrollador es obligatorio")]
        public required string Developer { get; set; }
        [Required(ErrorMessage = "La fecha de lanzamiento es obligatoria")]
        [DataType(DataType.Date)] 
        public DateOnly Release { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")] 
        public required string Description { get; set; }
    }
}
