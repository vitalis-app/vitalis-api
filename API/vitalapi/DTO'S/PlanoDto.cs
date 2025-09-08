namespace vitalapi.DTO_S
{
    public class PlanoReadDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public TipoPlano PlanoTipo { get; set; }
        public List<Funcionalidade> Funcionalidades { get; set; }
    }
}