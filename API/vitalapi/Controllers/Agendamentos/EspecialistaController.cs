using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Models.Especialista;

using EspecialistaModel = vitalapi.Models.Especialista.Especialista;

namespace vitalapi.Controllers.Especialista
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialistaController : ControllerBase
    {
        private readonly VitalContext _context;

        public EspecialistaController(VitalContext vitalcontext)
        {
            _context = vitalcontext;
        }

        // GET: api/disponibilidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialistaModel>>> GetEspecialista()
        {
            return await _context.Especialistas.ToListAsync();
        }

        // GET: api/disponibilidade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialistaModel>> GetEspecialista(int id)
        {
            var especialista = await _context.Especialistas.FindAsync(id);

            if (especialista == null)
            {
                return NotFound();
            }

            return especialista;
        }

        // POST: api/disponibilidade
        [HttpPost]
        public async Task<ActionResult<EspecialistaModel>> PostEspecialista(EspecialistaModel especialista)
        {
            _context.Especialistas.Add(especialista);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEspecialista), new { id = especialista.Id }, especialista);
        }

        // PUT: api/disponibilidade/5   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialista(int id, EspecialistaModel especialista)
        {
            if (id != especialista.Id)
            {
                return BadRequest();
            }

            _context.Entry(especialista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialistaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/disponibilidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialista(int id)
        {
            var especialista = await _context.Especialistas.FindAsync(id);
            if (especialista == null)
            {
                return NotFound();
            }

            _context.Especialistas.Remove(especialista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialistaExists(int id)
        {
            return _context.Especialistas.Any(e => e.Id == id);
        }
    }
}
