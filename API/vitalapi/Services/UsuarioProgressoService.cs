using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Models.Usuario;

public class UsuarioProgressoService
{
    private readonly VitalContext _context;
    private readonly IMapper _mapper;

    public UsuarioProgressoService(VitalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsuarioProgressoDashboardDto> GetProgressoDashboardAsync(int usuarioId)
    {
        var progresso = await _context.UsuarioProgressos
            .Include(p => p.Usuario).ThenInclude(u => u.VideosAssistidos)
            .Include(p => p.Humores)
            .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);

        if (progresso == null) return null;

        var emocaoFrequente = CalcularEmocaoFrequente(progresso.Humores);
        var (xpDaSemana, mensagem) = CalcularXpDaSemana(usuarioId);

        var dashboardDto = new UsuarioProgressoDashboardDto
        {
            DiasAtivos = progresso.DiasAtivosStreak,
            XpTotal = progresso.XPTotal,
            VideosAssistidos = progresso.QuantidadeVideosAssistidos,
            EmocaoFrequente = emocaoFrequente,
            XpGanhoNaSemana = xpDaSemana,
            MensagemDoDia = mensagem
        };

        return dashboardDto;
    }

    public async Task<bool> RegistrarCheckinAsync(int usuarioId)
    {
        var progresso = await _context.UsuarioProgressos.FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);
        if (progresso == null) return false;

        progresso.RegistrarAtividade();
        progresso.QuantidadeCheckins++;

        await _context.SaveChangesAsync();
        return true;
    }

    private string CalcularEmocaoFrequente(ICollection<UsuarioHumor> humores)
    {
        if (humores == null || !humores.Any()) return "Indefinido";

        var emocao = humores
            .GroupBy(h => h.Humor)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();

        return emocao.ToString() ?? "Tranquilo";
    }

    private (List<XpDiarioDto>, string) CalcularXpDaSemana(int usuarioId)
    {
        var semana = new List<XpDiarioDto>
        {
            new() { Dia = "Dom", Xp = 180 },
            new() { Dia = "Seg", Xp = 260 },
            new() { Dia = "Ter", Xp = 320 },
            new() { Dia = "Qua", Xp = 180 },
            new() { Dia = "Qui", Xp = 220 },
            new() { Dia = "Sex", Xp = 280 },
            new() { Dia = "Sáb", Xp = 150 },
        };

        var maisProdutivo = semana.OrderByDescending(d => d.Xp).First();
        var mensagem = $"{maisProdutivo.Dia} foi seu dia mais produtivo com {maisProdutivo.Xp} XP!";

        return (semana, mensagem);
    }
}