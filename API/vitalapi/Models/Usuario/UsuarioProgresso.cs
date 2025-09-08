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

        public ICollection<UsuarioHumor> Humores { get; set; } = new List<UsuarioHumor>();

        public ICollection<UsuarioConquista> UsuariosConquistas { get; set; }

        public int QuantidadeVideosAssistidos => Usuario.VideosAssistidos?.Count ?? 0;
        public int QuantidadeSessoes => Usuario.SessoesUsuario?.Count ?? 0;


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