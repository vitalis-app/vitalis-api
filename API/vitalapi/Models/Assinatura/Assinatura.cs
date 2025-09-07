
using UsuarioModel = vitalapi.Models.Usuario.Usuario;

namespace vitalapi.Models.Assinatura
{
    public class Assinatura
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime Vencimento { get; set; }
        public Status StatusAtual { get; set; }
        public int PlanoId { get; set; }
        public Plano Plano { get; set; }
    } 
}