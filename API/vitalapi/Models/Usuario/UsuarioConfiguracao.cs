using vitalapi.Models.Configuracao;

namespace vitalapi.Models.Usuario
{
    public class UsuarioConfiguracao
    {
        public int Id { get; set; }
        public NotificacaoConfig PreferenciaNotificacoes { get; set; }
        public List<Dispositivo> DispositivosConectados { get; set; } = new();

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}