using vitalapi.Models.Midia;

namespace vitalapi.Models.Usuario
{
    public class UsuarioVideo
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }

        public DateTime DataAssistido { get; set; }
    }
}