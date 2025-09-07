using vitalapi.Models.Conquistas;
using vitalapi.Models.Usuario;

public class UsuarioConquista
{
    public int ID { get; set; }

    public int UsuarioProgressoId { get; set; }
    public UsuarioProgresso UsuarioProgresso { get; set; }

    public int ConquistaId { get; set; }
    public Conquista Conquista { get; set; }

    public int ProgressoConquista { get; set; }
    public DateTime DataConclusao { get; set; }
    public StatusPendencia StatusConquista { get; set; }
}