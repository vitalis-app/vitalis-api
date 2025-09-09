public class VideoCreateDTO
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Url { get; set; }
    public int DuracaoSegundos { get; set; }
    public string Categoria { get; set; }
    public List<int> TagIds { get; set; }
    public bool Ativo { get; set; }
    public bool Premium { get; set; }
}
