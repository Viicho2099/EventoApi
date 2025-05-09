using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models
{
    public class PonenteEvento
    {
        [Key]
        public int PonenteEventoId { get; set; }  // Clave primaria para la tabla intermedia

        public int EventoId { get; set; }
        public Evento? Evento { get; set; }

        public int PonenteId { get; set; }
        public Ponente? Ponente { get; set; }
    }
}
