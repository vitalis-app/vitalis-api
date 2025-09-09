using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using vitalapi.Models.Configuracao;

namespace vitalapi.Models.Usuario
{
    [Owned]
    public class UsuarioConfiguracao
    {
        [Required]
        public NotificacaoConfig PreferenciaNotificacoes { get; set; }
        [Required]
        public List<Dispositivo> DispositivosConectados { get; set; } = new();
    }
}