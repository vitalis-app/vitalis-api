using Microsoft.EntityFrameworkCore;
using vitalapi.Models.Configuracao;

namespace vitalapi.Models.Especialista
{
    [Owned]
    public class EspecialistaConfiguracao
    {
        public NotificacaoConfig PreferenciaNotificacoes { get; set; }
        public List<Dispositivo> DispositivosConectados { get; set; } = new();
    }
    // TO-DO: Configurações adequadas para especialistas
}