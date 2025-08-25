using System.Numerics;

public class RegistroEmocional
{
    const int XPBase = 100;
    const int XPMax = 200;

    public int Id { get; set; }
    public DateTime DiaRegistrado { get; set; }
    public Humor HumorRegistrado { get; set; }
    public int CalcularXPGanho(int diasAtivosStreak) => Math.Min(XPBase + (diasAtivosStreak * 5), XPMax);
    public string ConfissaoUsuario { get; set; }
}