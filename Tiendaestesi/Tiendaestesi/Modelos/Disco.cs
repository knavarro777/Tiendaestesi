using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Tiendaestesi.Modelos
{
    public class Disco
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo del disco es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "El artista del disco es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string? Artista { get; set; }
        [Required(ErrorMessage = "El genero del disco es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string? Genero { get; set; }
        [Required(ErrorMessage = "El año de lanzamiento del disco es obligatorio")]
        [Range(1900, 2100, ErrorMessage = "Año no válido")]
        public int An_Lanzamiento { get; set; } = DateTime.Now.Year;
        [Required(ErrorMessage = "El precio del disco es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Precision(precision: 18, scale: 2)]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "El stock del disco es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock no puede ser negativo")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "La condicion del disco es obligatoria")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string? Condicion { get; set; }

        public virtual ICollection<Venta>? Ventas { get; set; }
    }
}
