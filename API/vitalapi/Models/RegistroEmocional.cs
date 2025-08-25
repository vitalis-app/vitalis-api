using System.Numerics;

public class RegistroEmocional
{
    int Id { get; set; }
    const int XPBase = 100;
    const int XPMax = 200;
    public DateTime Dia { get; set; }
    public Humor HumorRegistrado { get; set; }
    public int CalcularXPGanho(int diasAtivosStreak) =>
    Math.Min(XPBase + (diasAtivosStreak * 5), XPMax);
    public string ConfissaoUsuario { get; set; }
}