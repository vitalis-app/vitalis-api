namespace vitalapi.DTO_S
{
    public class DisponibilidadeCreateDto
    {
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public DayOfWeek DiaSemana { get; set; }
    }
    public class DisponibilidadeReadDto
    {
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public DayOfWeek DiaSemana { get; set; }
    }
    public class DisponibilidadeUpdateDto
    {
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public DayOfWeek DiaSemana { get; set; }
    }
}
