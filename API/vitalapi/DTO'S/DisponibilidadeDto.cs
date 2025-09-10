using System.ComponentModel.DataAnnotations;

public class DisponibilidadeReadDto
{
    public int Id { get; set; }
    public DayOfWeek DiaDaSemana { get; set; }
    public string HorarioInicio { get; set; }
    public string HorarioFim { get; set; }
}

public class DisponibilidadeCreateDto
{
    [Required]
    public DayOfWeek? DiaDaSemana { get; set; }

    [Required]
    [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Horário deve estar no formato HH:mm")]
    public string HorarioInicio { get; set; }

    [Required]
    [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Horário deve estar no formato HH:mm")]
    public string HorarioFim { get; set; }
}