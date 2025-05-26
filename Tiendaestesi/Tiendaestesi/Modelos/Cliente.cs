using System.ComponentModel.DataAnnotations;

namespace Tiendaestesi.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El campo Correo no puede tener más de 100 caracteres.")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El campo Teléfono debe contener exactamente 10 dígitos.")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        public DateTime FechaVenta { get; set; }  = DateTime.Now;

        public virtual ICollection<Venta>? Ventas { get; set; }
    }
}
