namespace vitalapi.Models.Especialista
{
    public class Disponibilidade
    {
        public int Id { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public List<DayOfWeek > DiasDaSemana { get; set; }
    }
}
