using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }  // Clave primaria
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public string Tipo { get; set; }  // Taller, conferencia, webinar, etc.

        // Relación uno a muchos con las sesiones
        public ICollection<Sesion> Sesiones { get; set; }

        // Relación muchos a muchos con los ponentes
        public ICollection<PonenteEvento> PonentesEventos { get; set; }

        // Relación muchos a muchos con los participantes
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
