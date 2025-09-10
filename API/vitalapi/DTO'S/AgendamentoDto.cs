public class AgendamentoReadDto
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public StatusPendencia StatusAtual { get; set; }
    public decimal ValorPago { get; set; }

    public int UsuarioId { get; set; }
    public string UsuarioNome { get; set; }
    public int EspecialistaId { get; set; }
    public string EspecialistaNome { get; set; }
}

public class AgendamentoCreateDto
{
    public int UsuarioId { get; set; }
    public int EspecialistaId { get; set; }
    public DateTime DataHora { get; set; }
}

public class AgendamentoUpdateDto
{
    public StatusPendencia StatusAtual { get; set; }
}