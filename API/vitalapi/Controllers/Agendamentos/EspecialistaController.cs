using Microsoft.AspNetCore.Mvc;
using vitalapi.DTO_S;
using vitalapi.Services;

namespace vitalapi.Controllers.Especialista
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialistaController : ControllerBase
    {
        private readonly EspecialistaService _service;

        public EspecialistaController(EspecialistaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialistaReadDto>>> GetEspecialistas()
        {
            var especialistas = await _service.GetAllAsync();
            return Ok(especialistas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialistaReadDto>> GetEspecialista(int id)
        {
            var especialista = await _service.GetByIdAsync(id);
            if (especialista == null) return NotFound();
            return Ok(especialista);
        }

        [HttpPost]
        public async Task<ActionResult<EspecialistaReadDto>> PostEspecialista(EspecialistaCreateDto createDto)
        {
            var novoEspecialista = await _service.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetEspecialista), new { id = novoEspecialista.Id }, novoEspecialista);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialista(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}