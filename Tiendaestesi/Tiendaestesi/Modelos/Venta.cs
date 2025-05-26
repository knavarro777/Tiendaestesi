using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiendaestesi.Modelos
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cliente es obligatorio.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo Disco es obligatorio.")]
        [Display(Name = "Disco")]
        public int DiscoId { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Venta es obligatorio.")]
        [Display(Name = "Fecha de Venta")]
        public DateTime FechaVenta { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100.")]
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        [StringLength(50, ErrorMessage = "El método de pago no puede exceder 50 caracteres.")]
        [Display(Name = "Método de Pago")]
        public string MetodoPago { get; set; } = "Efectivo";

       
        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("DiscoId")]
        public virtual Disco? Disco { get; set; }
    }
}
