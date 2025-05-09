using EventoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventoApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        public DbSet<Evento> Eventos1 { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Ponente> Ponentes { get; set; }
        public DbSet<PonenteEvento> PonentesEventos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la precisión y escala para el campo 'Monto' en 'Pago'
            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasPrecision(18, 2); // 18 para la precisión total y 2 para los decimales

            // Otras configuraciones si es necesario
            modelBuilder.Entity<PonenteEvento>()
                .HasKey(pe => new { pe.EventoId, pe.PonenteId });

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Evento)
                .WithMany(e => e.Inscripciones)
                .HasForeignKey(i => i.EventoId);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Participante)
                .WithMany(p => p.Inscripciones)
                .HasForeignKey(i => i.ParticipanteId);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Inscripcion)
                .WithMany(i => i.Pagos)
                .HasForeignKey(p => p.InscripcionId);
        }
    }
}
