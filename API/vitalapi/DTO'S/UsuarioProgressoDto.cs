public class XpDiarioDto
{
    public string Dia { get; set; }
    public int Xp { get; set; }
}

public class UsuarioProgressoDashboardDto
{
    public int DiasAtivos { get; set; }
    public int XpTotal { get; set; }
    public string EmocaoFrequente { get; set; }
    public int VideosAssistidos { get; set; }
    public List<XpDiarioDto> XpGanhoNaSemana { get; set; }
    public string MensagemDoDia { get; set; }
}