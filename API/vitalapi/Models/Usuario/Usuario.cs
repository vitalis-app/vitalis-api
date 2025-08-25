using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace vitalapi.Models.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } // TO-DO: Fazer hash da senha
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public UsuarioPerfil Perfil { get; set; }
        public UsuarioProgresso Progresso { get; set; }
        public ConfiguracoesUsuario Configuracoes { get; set; }
        public Planta PlantaAtual { get; set; }
        public List<Planta> Jardim { get; set; } = new();

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
