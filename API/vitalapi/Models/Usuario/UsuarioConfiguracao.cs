using Microsoft.EntityFrameworkCore;
using vitalapi.Models.Configuracao;

namespace vitalapi.Models.Usuario
{
    [Owned]
    public class UsuarioConfiguracao
    {
        public NotificacaoConfig PreferenciaNotificacoes { get; set; }
        public List<Dispositivo> DispositivosConectados { get; set; } = new();
    }
}