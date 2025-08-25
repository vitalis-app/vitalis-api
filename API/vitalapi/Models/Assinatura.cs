namespace vitalapi.Models
{
    public class Assinatura
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime Vencimento { get; set; }
        public Status StatusAtual { get; set; }
        public bool Pago { get; set; }
        
    }
}
