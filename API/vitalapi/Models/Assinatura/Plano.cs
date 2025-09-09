namespace vitalapi.Models.Assinatura
{
    public class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        //public TipoPlano PlanoTipo { get; set; }
        //public List<Funcionalidade> Funcionalidades { get; set; }
        //public List<Assinatura> Assinaturas { get; set; }
    }
}