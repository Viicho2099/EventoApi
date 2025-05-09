using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models
{
    public class Sesion
    {
        [Key]
        public int SesionId { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        // Clave foránea
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }  // Atributo de navegación
    }
}
