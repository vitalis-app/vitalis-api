using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Models.Especialista;

namespace vitalapi.Controllers.Especialista
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly VitalContext _context;

        public AgendamentoController(VitalContext vitalcontext)
        {
            _context = vitalcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamento()
        {
            return await _context.Especialista.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            var agendamento = await _context.Especialista.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return agendamento;
        }
        [HttpPost]
        public async Task<ActionResult<Agendamento>> Postagendamento(Agendamento agendamento)
        {
            _context.Especialista.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.Id }, agendamento);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssinatura(int id, Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;

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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Especialista.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Especialista.Remove(agendamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialistaExists(int id)
        {
            return _context.Especialista.Any(e => e.Id == id);
        }

    }
}
