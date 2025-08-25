using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Models;

namespace vitalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConquistaController : ControllerBase
    {
        private readonly VitalContext _context;

        public ConquistaController(VitalContext vitalcontext)
        {
            _context = vitalcontext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conquista>>> GetConquistas()
        {
            return await _context.Conquistas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conquista>> GetConquista(int id)
        {
            var conquista = await _context.Conquistas.FindAsync(id);

            if (conquista == null)
            {
                return NotFound();
            }

            return conquista;
        }


        [HttpPost]
        public async Task<ActionResult<Conquista>> PostConquista(Conquista conquista)
        {
            _context.Conquistas.Add(conquista);
            await _context.SaveChangesAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction(nameof(GetConquista), new { id = conquista.Id }, conquista);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutConquista(int id, Conquista conquista)
        {
            if (id != conquista.Id)
            {
                return BadRequest();
            }

            _context.Entry(conquista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConquistaExists(id))
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
        public async Task<IActionResult> DeleteConquista(int id)
        {
            var conquista = await _context.Conquistas.FindAsync(id);
            if (conquista == null)
            {
                return NotFound();
            }

            _context.Conquistas.Remove(conquista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConquistaExists(int id)
        {
            return _context.Conquistas.Any(e => e.Id == id);
        }

    }
}
