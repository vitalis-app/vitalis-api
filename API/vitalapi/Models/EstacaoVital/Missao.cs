using vitalapi.Models.Usuario;

namespace vitalapi.Models.EstacaoVital
{
    public class Missao
    {
        public int Id { get; set; }

        public ICollection<UsuarioMissao> UsuarioMissoes { get; set; }

        public string Descricao { get; set; }
        public int QuantidadeXP { get; set; }
        public ObjetivoTipo ObjetivoTipo { get; set; }
        public int QuantidadeObjetivo { get; set; }
    }
}