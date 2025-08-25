using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace vitalapi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string FotoPerfil { get; set; }
        public string PlanoId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }

        // Plantas
        public List<Planta> Jardim { get; set; } = new();
        public Planta PlantaAtual { get; set; }

        // Conquistas
        public List<Conquista> Conquistas { get; set; } = new();

        // Vídeos e sessões
        public List<Video> VideosAssistidos { get; set; } = new();
        public int QuantidadeVideosAssistidos => VideosAssistidos?.Count ?? 0;
        public int QuantidadeSessoes { get; set; }
        public List<SessaoUsuario> SessoesUsuario { get; set; } = new();

        // Jornada do usuário
        public int XPTotal { get; set; }
        public int QuantidadeCheckins { get; set; }
        public DateTime? UltimaAtividade { get; set; }
        public int DiasAtivosStreak { get; set; }
        public int TempoMedioUsuario { get; set; }

        // Humor
        private List<Humor> ListaHumores { get; set; } = new();
        public Humor HumorFrequente => ListaHumores
            .GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .FirstOrDefault()
            .Key;

        // Planta - rega
        public DateTime UltimaRega { get; set; }
        public bool PodeRegar => UltimaRega.Date < DateTime.Today;

        // Dispositivos conectados
        public List<DispositivoConectado> DispositivosConectados { get; set; } = new();

        // Preferências de notificação
        public NotificacaoConfig PreferenciasNotificacoes { get; set; }

        public void RegistrarAtividade()
        {
            var hoje = DateTime.Today;

            if (UltimaAtividade == null)
            {
                DiasAtivosStreak = 1;
            }

            else
            {
                var ultimaAtividade = UltimaAtividade.Value.Date;

                if (ultimaAtividade == hoje)
                {
                    return;
                }
                else if (ultimaAtividade == hoje.AddDays(-1))
                {
                    DiasAtivosStreak += 1;
                }
                else
                {
                    DiasAtivosStreak = 1;
                }
            }

            UltimaAtividade = hoje;
        }
    }
}
