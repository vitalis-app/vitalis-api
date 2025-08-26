using Microsoft.EntityFrameworkCore;
using vitalapi.Models.Especialista;
using vitalapi.Models.Assinatura;
using vitalapi.Models.Usuario;
using vitalapi.Models.Midia;
using vitalapi.Models.Usuario.Conquistas;

namespace vitalapi.Context
{
    public class VitalContext : DbContext
    {
        // A linha 'internal object Assinatura;' foi REMOVIdA daqui.

        public VitalContext(DbContextOptions<VitalContext> options) : base(options) { }

        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Agendamento> Especialista { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Especialista> Especialistas { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conquista> Conquistas { get; set; }
        public DbSet<Video> Videos { get; set; }
        // outras DbSets...
    }
}