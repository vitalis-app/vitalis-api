using System.ComponentModel.DataAnnotations;
using vitalapi.Models.Assinatura;

namespace vitalapi.DTO_S
{
    public class AssinaturaCreateDto
    {
        [Required]
        public int PlanoId { get; set; }
        // TO-DO: Funcionalidade de pagamento -> [Required] public string TokenPagamento { get; set; }
        // TO-DO: Funcionalidade de cupom -> public string? CupomDesconto { get; set; } 
    }
    public class AssinaturaReadDto
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataVencimento { get; set; }
        public Status StatusAtual { get; set; }
    }
    public class AssinaturaUpdateDto
    {
        public int PlanoId { get; set; }
        public Status Status { get; set; }
    }
}
