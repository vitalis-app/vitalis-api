using vitalapi.Models.Especialista;
using vitalapi.Models.EstacaoVital;
using vitalapi.Models.Pessoa;
using AssinaturaModel = vitalapi.Models.Assinatura.Assinatura;

namespace vitalapi.Models.Usuario
{
    public class Usuario : PessoaBase
    {
        public UsuarioProgresso Progresso { get; set; }
        public int UsuarioProgressoId { get; set; }

        public AssinaturaModel AssinaturaAtiva { get; set; }
        public int? AssinaturaAtivaId { get; set; }

        public ICollection<UsuarioPlanta> UsuarioPlantas { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }
        public ICollection<RegistroEmocional> RegistrosEmocionais { get; set; }

        public UsuarioConfiguracao Configuracoes { get; set; }

    }
}