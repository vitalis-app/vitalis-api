namespace vitalapi.DTO_S
{
    public class UsuarioConfiguracaoReadDto
    {
        public NotificacaoConfigReadDto PreferenciaNotificacoes { get; set; }
        public List<DispositivoReadDto> DispositivosConectados { get; set; } = new();
    }
    public class NotificacaoConfigReadDto
    {
        public bool AlertaDiarioAtivo { get; set; }
        public bool LembreteSessaoAtivo { get; set; }
        public bool NotificacaoVideoAtiva { get; set; }
        public MetodoNotificacao Preferencia { get; set; }
    }
    public class DispositivoReadDto
    {
        public string Nome { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
    }
}
