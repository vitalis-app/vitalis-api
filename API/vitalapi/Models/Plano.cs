namespace vitalapi.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public TipoPlano Tipo { get; set; }
        public List<Funcionalidade> Funcionalidades { get; set; }
    }
}
