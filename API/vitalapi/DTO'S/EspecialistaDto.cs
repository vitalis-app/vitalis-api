using vitalapi.Models.Especialista;

public class EspecialistaCreateDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Genero { get; set; }
    public string FotoPerfil { get; set; }
    public string Crp { get; set; }
    public string Biografia { get; set; }
    public decimal ValorConsulta { get; set; }
    public List<int> EspecialidadeIds { get; set; } = new List<int>();
}

public class EspecialistaReadDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Crp { get; set; }
    public string Biografia { get; set; }
    public decimal ValorConsulta { get; set; }
    public double AvaliacaoMedia { get; set; }
    public ICollection<EspecialidadeReadDto> Especialidades { get; set; } 
}

public class EspecialistaUpdateDto
{
    public string Nome { get; set; }
    public string Biografia { get; set; }
    public decimal ValorConsulta { get; set; }
    public List<int> EspecialidadeIds { get; set; }
}

public class EspecialidadeReadDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}