namespace vitalapi.Models
{
    public class NotificacaoConfig
    {
        public bool AlertaDiarioAtivo { get; set; }
        public bool LembreteSessaoAtivo { get; set; }
        public bool NotificacaoVideoAtiva { get; set; }
        public MetodoNotificacao Preferencia { get; set; }
    }
}