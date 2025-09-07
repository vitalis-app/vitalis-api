namespace vitalapi.Models.Configuracao
{
    public class NotificacaoConfig
    {
        public int Id { get; set; }
        public bool AlertaDiarioAtivo { get; set; }
        public bool LembreteSessaoAtivo { get; set; }
        public bool NotificacaoVideoAtiva { get; set; }
        public MetodoNotificacao Preferencia { get; set; }
    }
}