namespace vitalapi.Models.Configuracao
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
    }
}