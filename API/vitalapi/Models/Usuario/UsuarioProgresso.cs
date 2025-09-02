using vitalapi.Models.Conquistas;
using vitalapi.Models.Midia;

namespace vitalapi.Models.Usuario
{
    public class UsuarioProgresso
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int XPTotal { get; set; }
        public int DiasAtivosStreak { get; set; }
        public DateTime? UltimaAtividade { get; set; }
        public int QuantidadeCheckins { get; set; }
        public int TempoMedioUsuario { get; set; }

        public List<Humor> ListaHumores { get; set; } = new();
        public Humor HumorFrequente => ListaHumores
            .GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .FirstOrDefault()
            .Key;

        public ICollection<Conquista> Conquistas { get; set; }

        public ICollection<Video> VideosAssistidos { get; set; }
        public int QuantidadeVideosAssistidos => VideosAssistidos?.Count ?? 0;

        public ICollection<UsuarioSessao> SessoesUsuario { get; set; }
        public int QuantidadeSessoes => SessoesUsuario?.Count ?? 0;


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