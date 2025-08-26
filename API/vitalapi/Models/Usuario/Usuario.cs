using Microsoft.EntityFrameworkCore.Metadata.Internal;
using vitalapi.Models.Assinatura;
using vitalapi.Models.EstacaoVital;
using vitalapi.Models.Pessoa;

namespace vitalapi.Models.Usuario
{
    public class Usuario : PessoaBase
    {
        public UsuarioProgresso Progresso { get; set; }
        public Planta PlantaAtual { get; set; }
        public List<Planta> Jardim { get; set; } = new();
        public UsuarioConfiguracao Configuracoes { get; set; }

        public int PlanoId { get; set; }
        public Plano Plano { get; set; }

        public void RegistrarAtividade()
        {
            var hoje = DateTime.Today;

            if (Progresso.UltimaAtividade == null)
            {
                Progresso.DiasAtivosStreak = 1;
            }

            else
            {
                var ultimaAtividade = Progresso.UltimaAtividade.Value.Date;

                if (ultimaAtividade == hoje)
                {
                    return;
                }
                else if (ultimaAtividade == hoje.AddDays(-1))
                {
                    Progresso.DiasAtivosStreak += 1;
                }
                else
                {
                    Progresso.DiasAtivosStreak = 1;
                }
            }

            Progresso.UltimaAtividade = hoje;
        }
    }
}
