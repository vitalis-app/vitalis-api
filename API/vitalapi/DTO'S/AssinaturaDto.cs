namespace vitalapi.DTO_S
{
    public class AssinaturaDto
    {
        public int Id { get; set; }
        public string DataInicio { get; set; }
        public string Vencimento { get; set; }
        public string Status { get; set; }
        public bool Pago { get; set; }
    }
    public class CreateAssinaturaDto
    {
        public string DataInicio { get; set; }
        public string Vencimento { get; set; }
        public string Status { get; set; }
        public bool Pago { get; set; }
    }
    public class ReadAssinaturaDto
    {
        public DateTime DataInicio { get; set; }
        public DateTime Vencimento { get; set; }
        public Status StatusAtual { get; set; }
    }
    public class UpdateAssinaturaDto
    {
        public string Status { get; set; }
        public bool Pago { get; set; }
    }
}
