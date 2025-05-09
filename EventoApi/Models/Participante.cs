using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models
{
    public class Participante
    {
        [Key]
        public int ParticipanteId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Relación con inscripciones
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
