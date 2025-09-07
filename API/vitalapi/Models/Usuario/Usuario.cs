using vitalapi.Models.Especialista;
using vitalapi.Models.EstacaoVital;
using vitalapi.Models.Midia;
using vitalapi.Models.Pessoa;
using AssinaturaModel = vitalapi.Models.Assinatura.Assinatura;

namespace vitalapi.Models.Usuario
{
    public class Usuario : PessoaBase
    {
        public UsuarioProgresso Progresso { get; set; }

        public AssinaturaModel AssinaturaAtiva { get; set; }
        public int AssinaturaAtivaId { get; set; }

        public UsuarioConfiguracao Configuracoes { get; set; }
        public ICollection<Video> VideosAssistidos { get; set; } = new List<Video>();
        public ICollection<UsuarioSessao> SessoesUsuario { get; set; } = new List<UsuarioSessao>();
        public ICollection<UsuarioPlanta> UsuarioPlantas { get; set; } = new List<UsuarioPlanta>();
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        public ICollection<RegistroEmocional> RegistrosEmocionais { get; set; } = new List<RegistroEmocional>();
        public ICollection<UsuarioMissao> Missoes { get; set; } = new List<UsuarioMissao>();
    }
}