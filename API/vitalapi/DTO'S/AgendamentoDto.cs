using System.ComponentModel.DataAnnotations;

namespace vitalapi.DTO_S
{
    public class AgendamentoCreateDto
    {
        [Required]
        public int EspecialistaId { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
    }
    public class AgendamentoReadDto
    {
        public int EspecialistaId { get; set; }
        public string EspecialistaNome { get; set; }
        public DateTime DataHora { get; set; }
        public StatusPendencia Status { get; set; }
    }
    public class AgendamentoUpdateDto
    {
        public StatusPendencia Status { get; set; }
    }
}
