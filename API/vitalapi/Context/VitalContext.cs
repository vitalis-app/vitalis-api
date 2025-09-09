using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using vitalapi.Models.Assinatura;
using vitalapi.Models.Configuracao;
using vitalapi.Models.Conquistas;
using vitalapi.Models.Especialista;
using vitalapi.Models.EstacaoVital;
using vitalapi.Models.Usuario;

namespace vitalapi.Context
{
    public class VitalContext : DbContext
    {
        public VitalContext(DbContextOptions<VitalContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioProgresso> UsuarioProgressos { get; set; }
        public DbSet<UsuarioSessao> UsuarioSessoes { get; set; }
        public DbSet<UsuarioConquista> UsuarioConquistas { get; set; }
        public DbSet<UsuarioPlanta> UsuarioPlantas { get; set; }
        public DbSet<UsuarioMissao> UsuarioMissoes { get; set; }

        public DbSet<Especialista> Especialistas { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        public DbSet<Plano> Planos { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }

        public DbSet<Conquista> Conquistas { get; set; }
        public DbSet<Missao> Missoes { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<RegistroEmocional> RegistrosEmocionais { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<UsuarioHumor> UsuarioHumores { get; set; }

        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especialista>()
                .OwnsOne(e => e.Configuracoes, cfg =>
                {
                    cfg.OwnsOne(e => e.PreferenciaNotificacoes);

                    cfg.Property(e => e.DispositivosConectados)
                        .HasConversion(
                            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                            v => JsonSerializer.Deserialize<List<Dispositivo>>(v, (JsonSerializerOptions)null) ?? new List<Dispositivo>()
                        );
                });

            modelBuilder.Entity<Usuario>()
                .OwnsOne(u => u.Configuracoes, cfg =>
                {
                    cfg.OwnsOne(c => c.PreferenciaNotificacoes);

                    cfg.Property(c => c.DispositivosConectados)
                        .HasConversion(
                            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                            v => JsonSerializer.Deserialize<List<Dispositivo>>(v, (JsonSerializerOptions)null) ?? new List<Dispositivo>()
                        );
                });

            modelBuilder.Entity<UsuarioPlanta>()
                .HasKey(up => new { up.UsuarioId, up.PlantaId });

            modelBuilder.Entity<UsuarioHumor>()
                .HasKey(uh => uh.Id);

            modelBuilder.Entity<UsuarioHumor>()
                .HasOne(uh => uh.UsuarioProgresso)
                .WithMany(up => up.Humores)
                .HasForeignKey(uh => uh.UsuarioProgressoId);
            modelBuilder.Entity<Video>()
    .HasMany(v => v.Tags)
    .WithMany(t => t.Videos);
        }

    }
}