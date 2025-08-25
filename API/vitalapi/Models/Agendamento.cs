namespace vitalapi.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }    
        public Status StatusAtual { get; set; }
        public decimal ValorPago { get; set; }
    }
}
