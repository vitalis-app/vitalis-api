using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vitalapi.DTO_S;
using vitalapi.Services;

[Route("api/usuarios/{usuarioId}/progresso")]
[ApiController]
// [Authorize]
public class UsuarioProgressoController : ControllerBase
{
    private readonly UsuarioProgressoService _service;

    public UsuarioProgressoController(UsuarioProgressoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<UsuarioProgressoDashboardDto>> GetDashboard(int usuarioId)
    {
        var dashboard = await _service.GetProgressoDashboardAsync(usuarioId);
        if (dashboard == null) return NotFound("Progresso do usuário não encontrado.");

        return Ok(dashboard);
    }

    [HttpPost("checkin")]
    public async Task<IActionResult> FazerCheckin(int usuarioId)
    {
        var success = await _service.RegistrarCheckinAsync(usuarioId);
        if (!success) return NotFound("Progresso do usuário não encontrado.");

        return Ok(new { message = "Check-in registrado com sucesso!" });
    }
}