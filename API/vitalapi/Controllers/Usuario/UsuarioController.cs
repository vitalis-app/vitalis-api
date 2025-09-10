using Microsoft.AspNetCore.Mvc;
using vitalapi.DTO_S;
using vitalapi.Services;

namespace vitalapi.Controllers.UsuarioControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDto>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioReadDto>> PostUsuario(UsuarioCreateDto createDto)
        {
            var novoUsuarioDto = await _usuarioService.CreateAsync(createDto);

            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuarioDto.Id }, novoUsuarioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDto updateDto)
        {
            var success = await _usuarioService.UpdateAsync(id, updateDto);

            if (!success)
            {
                return NotFound();
            }

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var success = await _usuarioService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}