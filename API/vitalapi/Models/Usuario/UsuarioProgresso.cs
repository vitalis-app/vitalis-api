namespace vitalapi.Models.Usuario
{
    public class UsuarioProgresso
    {
        public int Id { get; set; }
        public int XPTotal { get; set; }
        public int DiasAtivosStreak { get; set; }
        public List<Conquista> Conquistas { get; set; } = new();
        public DateTime? UltimaAtividade { get; set; }
        public int QuantidadeCheckins { get; set; }
        public int TempoMedioUsuario { get; set; }

        public List<Humor> ListaHumores { get; set; } = new();
        public Humor HumorFrequente => ListaHumores
            .GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .FirstOrDefault()
            .Key;

        public List<Video> VideosAssistidos { get; set; } = new();
        public int QuantidadeVideosAssistidos => VideosAssistidos?.Count ?? 0;

        public List<UsuarioSessao> SessoesUsuario { get; set; } = new();
        public int QuantidadeSessoes => SessoesUsuario?.Count ?? 0;


        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}