using UsuarioModel = vitalapi.Models.Usuario.Usuario;

namespace vitalapi.Models.EstacaoVital
{
    public class RegistroEmocional
    {

        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        public DateTime DiaRegistrado { get; set; }
        public Humor HumorRegistrado { get; set; }
       public string ConfissaoUsuario { get; set; }
    }
}