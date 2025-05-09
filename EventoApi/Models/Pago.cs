using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }

        // Relación con Inscripción
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }
    }
}
