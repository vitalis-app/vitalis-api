
using vitalapi.Models.EstacaoVital;

namespace vitalapi.Models.Usuario
{
    public class UsuarioMissao
    { 
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int MissaoId { get; set; }
        public Missao Missao { get; set; }

        public int ProgressoConquista { get; set; }
        public bool isConluida { get; set; }
    }
}
