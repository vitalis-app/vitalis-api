using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Models.Especialista;

public class DisponibilidadeService
{
    private readonly VitalContext _context;
    private readonly IMapper _mapper;

    public DisponibilidadeService(VitalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Em vitalapi/Services/DisponibilidadeService.cs

    public async Task<DisponibilidadeReadDto> CreateAsync(int especialistaId, DisponibilidadeCreateDto dto)
    {
        var especialista = await _context.Especialistas.FindAsync(especialistaId);
        if (especialista == null) throw new KeyNotFoundException("Especialista não encontrado.");

        var horarioInicio = TimeOnly.Parse(dto.HorarioInicio);
        var horarioFim = TimeOnly.Parse(dto.HorarioFim);

        if (horarioFim <= horarioInicio)
            throw new InvalidOperationException("O horário de fim deve ser posterior ao horário de início.");

        var novoInicio = horarioInicio.ToTimeSpan();
        var novoFim = horarioFim.ToTimeSpan();

        var sobreposicao = await _context.Disponibilidades
            .AnyAsync(d => d.EspecialistaId == especialistaId &&
                           d.DiaDaSemana == dto.DiaDaSemana &&
                           d.HorarioFim.TimeOfDay > novoInicio && 
                           d.HorarioInicio.TimeOfDay < novoFim);

        if (sobreposicao)
            throw new InvalidOperationException("O novo horário se sobrepõe a uma disponibilidade já existente.");

        var entity = _mapper.Map<Disponibilidade>(dto);
        entity.EspecialistaId = especialistaId;

        _context.Disponibilidades.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<DisponibilidadeReadDto>(entity);
    }

    public async Task<IEnumerable<DisponibilidadeReadDto>> GetByEspecialistaIdAsync(int especialistaId)
    {
        var disponibilidades = await _context.Disponibilidades
            .Where(d => d.EspecialistaId == especialistaId)
            .OrderBy(d => d.DiaDaSemana).ThenBy(d => d.HorarioInicio)
            .ToListAsync();

        return _mapper.Map<IEnumerable<DisponibilidadeReadDto>>(disponibilidades);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Disponibilidades.FindAsync(id);
        if (entity == null) return false;

        // TO-DO: Regra de negócio - Não permitir deletar disponibilidade se houver agendamentos futuros nela.

        _context.Disponibilidades.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}