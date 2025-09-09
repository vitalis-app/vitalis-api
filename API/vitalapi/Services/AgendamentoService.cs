namespace vitalapi.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Especialista;

public class AgendamentoService
{
    private readonly VitalContext _context;
    private readonly IMapper _mapper;

    public AgendamentoService(VitalContext vitalcontext, IMapper mapper)
    {
        _context = vitalcontext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AgendamentoReadDto>> GetAllAsync()
    {
        var items = await _context.Agendamentos.ToListAsync();
        return _mapper.Map<IEnumerable<AgendamentoReadDto>>(items);
    }

    public async Task<IEnumerable<AgendamentoReadDto>> GetByUsuarioIdAsync(int usuarioId)
    {
        var items = await _context.Agendamentos
            .Include(a => a.Especialista)
            .Where(a => a.UsuarioId == usuarioId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AgendamentoReadDto>>(items);
    }

    public async Task<AgendamentoDto> CreateAsync(AgendamentoCreateDto dto)
    {
        var entity = _mapper.Map<Agendamento>(dto);
        _context.Agendamentos.Add(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<AgendamentoDto>(entity);
    }

    public async Task<bool> UpdateAsync(int id, AgendamentoUpdateDto dto)
    {
        var entity = await _context.Agendamentos.FindAsync(id);
        if (entity == null) return false;

        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Agendamentos.FindAsync(id);
        if (entity == null) return false;

        _context.Agendamentos.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
