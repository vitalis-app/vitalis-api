namespace vitalapi.Models.Especialista
{
    public class Disponibilidade
    {
        public int Id { get; set; }

        public int EspecialistaId { get; set; }
        public Especialista Especialista { get; set; }

        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public DayOfWeek DiaDaSemana { get; set; }

    }
}
