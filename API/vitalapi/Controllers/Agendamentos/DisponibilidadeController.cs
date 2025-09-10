using Microsoft.AspNetCore.Mvc;

[Route("api/especialistas/{especialistaId}/disponibilidade")]
[ApiController]
public class DisponibilidadeController : ControllerBase
{
    private readonly DisponibilidadeService _service;

    public DisponibilidadeController(DisponibilidadeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DisponibilidadeReadDto>>> GetDisponibilidade(int especialistaId)
    {
        var disponibilidades = await _service.GetByEspecialistaIdAsync(especialistaId);
        return Ok(disponibilidades);
    }

    [HttpPost]
    // [Authorize] 
    public async Task<ActionResult<DisponibilidadeReadDto>> AddDisponibilidade(int especialistaId, DisponibilidadeCreateDto createDto)
    {
        try
        {
            var novaDisponibilidade = await _service.CreateAsync(especialistaId, createDto);
            return Ok(novaDisponibilidade);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{disponibilidadeId}")]
    // [Authorize]
    public async Task<IActionResult> RemoveDisponibilidade(int especialistaId, int disponibilidadeId)
    {
        var success = await _service.DeleteAsync(disponibilidadeId);
        if (!success) return NotFound();
        return NoContent();
    }
}