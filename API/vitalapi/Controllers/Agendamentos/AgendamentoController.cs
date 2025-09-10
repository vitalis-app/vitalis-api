using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AgendamentosController : ControllerBase
{
    private readonly AgendamentoService _service;

    public AgendamentosController(AgendamentoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<AgendamentoReadDto>> CreateAgendamento(AgendamentoCreateDto createDto)
    {
        try
        {
            var novoAgendamento = await _service.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetAgendamentoById),
                new { id = novoAgendamento.Id },
                novoAgendamento);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AgendamentoReadDto>> GetAgendamentoById(int id)
    {
        var agendamento = await _service.GetByIdAsync(id);
        if (agendamento == null) return NotFound();
        return Ok(agendamento);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<ActionResult<IEnumerable<AgendamentoReadDto>>> GetAgendamentosPorUsuario(int usuarioId)
    {
        var agendamentos = await _service.GetByUsuarioIdAsync(usuarioId);
        return Ok(agendamentos);
    }
}