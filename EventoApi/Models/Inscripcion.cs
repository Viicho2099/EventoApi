using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models
{
    public class Inscripcion
    {
        [Key]
        public int InscripcionId { get; set; }
        public int ParticipanteId { get; set; }
        public int EventoId { get; set; }
        public DateTime FechaInscripcion { get; set; }

        // Relación con Evento
        public Evento Evento { get; set; }

        // Relación con Participante
        public Participante Participante { get; set; }

        // Relación con Pagos (uno a muchos)
        public ICollection<Pago> Pagos { get; set; }  // Aquí se define la propiedad de navegación
    }
}
