namespace vitalapi.Models
{
    public class Dispositivo
    {
        int Id { get; set; }
        string Nome { get; set; }
        TipoDispositivo TipoDispositivo { get; set; }
    }
}