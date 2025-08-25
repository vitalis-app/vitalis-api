namespace vitalapi.Models.Usuario
{
    public class ConfiguracoesUsuario
    {
        public int Id { get; set; }
        public NotificacaoConfig PreferenciasNotificacoes { get; set; }
        public List<Dispositivo> DispositivosConectados { get; set; } = new();

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}