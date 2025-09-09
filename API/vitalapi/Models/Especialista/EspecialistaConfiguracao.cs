using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using vitalapi.Models.Configuracao;

namespace vitalapi.Models.Especialista
{
    [Owned]
    public class EspecialistaConfiguracao
    {
        [Required]
        public NotificacaoConfig PreferenciaNotificacoes { get; set; } = new();
        [Required]
        public List<Dispositivo> DispositivosConectados { get; set; } = new();
    }
    // TO-DO: Configurações adequadas para especialistas
}