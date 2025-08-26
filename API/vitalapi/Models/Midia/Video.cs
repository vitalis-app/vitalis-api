namespace vitalapi.Models.Midia
{
    public class Video
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public int DuracaoSegundos { get; set; }
        public string Categoria { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Tag> Tags { get; set; } = new();
        public int Visualizacoes { get; set; }
        public int Curtidas { get; set; }
        public bool Ativo { get; set; }
        public bool Premium { get; set; }

        // TO-DO: Adicionar os valores "Titulo", "Descricao", "Visualizacoes" e "Curtidas" com a Youtube Data API
    }
}