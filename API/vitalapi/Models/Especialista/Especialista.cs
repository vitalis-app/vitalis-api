using vitalapi.Models.Pessoa;

namespace vitalapi.Models.Especialista
{
    public class Especialista : PessoaBase
    {
        List<Disponibilidade> DiasDisponiveis { get; set; } = new();
     
        List<Agendamento> Agendamentos { get; set; } = new();

        public ICollection<Especialidade> Especialidades { get; set; } = new List<Especialidade>();
        public string CRP { get; set; }
        public string Biografia { get; set; }
        public decimal ValorConsulta { get; set; }
        public double AvaliacaoMedia { get; set; }
        public EspecialistaConfiguracao Configuracoes { get; set; }
    }
}
