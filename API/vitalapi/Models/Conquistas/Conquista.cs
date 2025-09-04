namespace vitalapi.Models.Conquistas
{
    public class Conquista
    {
        public int Id { get; set; }

        public ICollection<UsuarioConquista> UsuariosConquistas { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeXP { get; set; }
        public ObjetivoTipo ObjetivoTipo { get; set; }
        public int QuantidadeObjetivo { get; set; }
    }
}