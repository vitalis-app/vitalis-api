using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Services;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly VitalContext _context;

    public AuthController(TokenService tokenService, VitalContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (usuario == null)
            return Unauthorized("Email ou senha inválidos.");

        if ("HASHED_" + loginDto.Senha != usuario.Senha)
        {
            return Unauthorized("Email ou senha inválidos.");
        }

        var token = _tokenService.GenerateToken(usuario);

        return Ok(new { token });
    }
}