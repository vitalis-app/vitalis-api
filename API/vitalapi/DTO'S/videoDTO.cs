public class CreateVideoDto
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Url { get; set; }
    public int DuracaoSegundos { get; set; }
    public string Categoria { get; set; }
    public List<int> Tags { get; set; } // IDs das tags
    public bool Ativo { get; set; }
    public bool Premium { get; set; }
}
