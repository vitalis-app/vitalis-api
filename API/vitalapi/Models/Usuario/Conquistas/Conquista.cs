namespace vitalapi.Models.Usuario.Conquistas
{
    public class Conquista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeXP { get; set; }
        public ObjetivoTipo ObjetivoTipo { get; set; }
        public int QuantidadeObjetivo { get; set; }
    }
}