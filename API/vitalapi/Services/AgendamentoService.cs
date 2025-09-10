using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Especialista;

public class AgendamentoService
{
    private readonly VitalContext _context;
    private readonly IMapper _mapper;

    public AgendamentoService(VitalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AgendamentoReadDto> CreateAsync(AgendamentoCreateDto dto)
    {
        // TO-DO: Validação de Negócio
        // 1. Verificar se o horário está dentro da disponibilidade do especialista.
        // 2. Verificar se o especialista já não tem uma consulta nesse horário.
        var horarioOcupado = await _context.Agendamentos
            .AnyAsync(a => a.EspecialistaId == dto.EspecialistaId && a.DataHora == dto.DataHora);

        if (horarioOcupado)
        {
            throw new InvalidOperationException("Este horário não está mais disponível.");
        }

        var especialista = await _context.Especialistas.FindAsync(dto.EspecialistaId);
        if (especialista == null)
        {
            throw new KeyNotFoundException("Especialista não encontrado.");
        }

        var entity = _mapper.Map<Agendamento>(dto);

        entity.StatusAtual = StatusPendencia.Concluido;
        entity.ValorPago = especialista.ValorConsulta;

        _context.Agendamentos.Add(entity);
        await _context.SaveChangesAsync();

        await _context.Entry(entity).Reference(a => a.Usuario).LoadAsync();

        return _mapper.Map<AgendamentoReadDto>(entity);
    }

    public async Task<AgendamentoReadDto> GetByIdAsync(int id)
    {
        var agendamento = await _context.Agendamentos
            .Include(a => a.Usuario)
            .Include(a => a.Especialista)
            .FirstOrDefaultAsync(a => a.Id == id);

        return _mapper.Map<AgendamentoReadDto>(agendamento);
    }

    public async Task<IEnumerable<AgendamentoReadDto>> GetByUsuarioIdAsync(int usuarioId)
    {
        var agendamentos = await _context.Agendamentos
            .Where(a => a.UsuarioId == usuarioId)
            .Include(a => a.Especialista)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AgendamentoReadDto>>(agendamentos);
    }
}