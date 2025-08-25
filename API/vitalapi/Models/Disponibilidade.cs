namespace vitalapi.Models
{
    public class Disponibilidade
    {
        public int Id { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public DayOfWeek DiaSemana { get; set; }
    }
}
