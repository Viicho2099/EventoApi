using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models
{
    public class Ponente
    {
        [Key]
        public int PonenteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Bio { get; set; }

        // Relación muchos a muchos con eventos
        public ICollection<PonenteEvento> PonentesEventos { get; set; }
    }
}
