using Microsoft.AspNetCore.Mvc;
using vitalapi.DTO_S;
using vitalapi.Services;

namespace vitalapi.Controllers.UsuarioControllers
{
    [Route("api/usuarios/{usuarioId}/estacaovital")]
    [ApiController]
    public class UsuarioPlantaController : ControllerBase
    {
        private readonly UsuarioPlantaService _service;

        public UsuarioPlantaController(UsuarioPlantaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioPlantaReadDto>>> GetPlantasDoUsuario(int usuarioId)
        {
            var plantas = await _service.GetByUsuarioAsync(usuarioId);
            return Ok(plantas);
        }

        [HttpPost("regar")] 
        public async Task<IActionResult> RegarPlantaAtiva(int usuarioId)
        {
            var resultado = await _service.RegarPlantaAtivaAsync(usuarioId);

            dynamic resultObj = resultado;
            if (!resultObj.success)
            {
                return BadRequest(new { message = resultObj.message });
            }

            return Ok(resultado);
        }

        [HttpPut("{plantaId}")]
        public async Task<IActionResult> RenomearPlanta(int usuarioId, int plantaId, UsuarioPlantaUpdateDto updateDto)
        {
            var success = await _service.UpdateAsync(usuarioId, plantaId, updateDto);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}