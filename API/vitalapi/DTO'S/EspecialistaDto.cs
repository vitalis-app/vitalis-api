namespace vitalapi.DTO_S
{
    public class EspecialistaCreateDto
    {
        public string Nome { get; set; }
        public ICollection<Especialidade> Especialidades { get; set; }
        public string Email { get; set; }
        public string Descricao { get; set; }
        public string CRP { get; set; }
        public string Biografia { get; set; }
        public decimal ValorConsulta { get; set; }
    }
    public class EspecialistaReadDto
    {
        public string Nome { get; set; }
        public ICollection<Especialidade> Especialidades  { get; set; }
        public string CRP { get; set; }
        public string Biografia { get; set; }
        public decimal ValorConsulta { get; set; }
        public double AvaliacaoMedia { get; set; }
    }   
    public class EspecialistaUpdateDto
    {
        public string Nome { get; set; }
        public ICollection<Especialidade> Especialidades { get; set; }
        public string Biografia { get; set; }
        public decimal ValorConsulta { get; set; }
    }
}
