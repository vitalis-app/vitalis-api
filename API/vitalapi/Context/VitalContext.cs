using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using vitalapi.Models.Assinatura;
using vitalapi.Models.Configuracao;
using vitalapi.Models.Conquistas;
using vitalapi.Models.Especialista;
using vitalapi.Models.EstacaoVital;
using vitalapi.Models.Midia;
using vitalapi.Models.Usuario;

namespace vitalapi.Context
{
    public class VitalContext : DbContext
    {
        public VitalContext(DbContextOptions<VitalContext> options) : base(options) { }


        public DbSet<Especialista> Especialistas { get; set; }


        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }


        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Plano> Planos { get; set; }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioProgresso> UsuarioProgressos { get; set; }
        public DbSet<UsuarioSessao> UsuarioSessoes { get; set; }
        public DbSet<UsuarioConquista> UsuarioConquistas { get; set; }
        public DbSet<UsuarioPlanta> UsuarioPlantas { get; set; }


        public DbSet<Conquista> Conquistas { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<RegistroEmocional> RegistrosEmocionais { get; set; }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .OwnsOne(u => u.Configuracoes, uc =>
                {
                    uc.OwnsOne(c => c.PreferenciaNotificacoes);
                    uc.OwnsOne(c => c.DispositivosConectados);
                });

            modelBuilder.Entity<Especialista>()
                .OwnsOne(e => e.Configuracoes);

            //modelBuilder.Entity<Usuario>()
            //  .OwnsOne(u => u.Configuracoes, cfg =>
            //   {
            //       cfg.Property(c => c.DispositivosConectados)
            //          .HasConversion(
            //              v => JsonSerializer.Serialize<List<Dispositivo>>(v),
            //              v => JsonSerializer.Deserialize<List<Dispositivo>>(v) ?? new List<Dispositivo>());
            //   });
        }
    }
}