using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Models;

namespace vitalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturaController : ControllerBase
    {
        private readonly VitalContext _context;

        public AssinaturaController (VitalContext vitalcontext)
        {
            _context = vitalcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assinatura>>> GetAssinatura()
        {
            return await _context.Assinaturas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assinatura>> GetAssinatura(int id)
        {
            var assinatura = await _context.Assinaturas.FindAsync(id);

            if (assinatura == null)
            {
                return NotFound();
            }

            return assinatura;
        }
        [HttpPost]
        public async Task<ActionResult<Assinatura>> PostAssinatura(Assinatura assinatura)
        {
            _context.Assinaturas.Add(assinatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssinatura), new { id = assinatura.Id }, assinatura);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssinatura(int id, Assinatura assinatura)
        {
            if (id != assinatura.Id)
            {
                return BadRequest();
            }

            _context.Entry(assinatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssinaturaExists(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssinatura(int id)
        {
            var assinatura = await _context. Assinaturas.FindAsync(id);
            if (assinatura == null)
            {
                return NotFound();
            }

            _context.Assinaturas.Remove(assinatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssinaturaExists(int id)
        {
            return _context.Assinaturas.Any(e => e.Id == id);
        }

    }
}
