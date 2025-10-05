using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendaVeiculos.Data;
using SistemaVendaVeiculos.Models;

namespace SistemaVendaVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlugueisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Alugueis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAlugueis()
        {
            // Usa dois Includes para fazer JOIN com Clientes e Veiculos
            return await _context.Alugueis
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .ThenInclude(v => v.Fabricante) // JOIN aninhado: Aluguel -> Veiculo -> Fabricante
                .ToListAsync();
        }

        // GET: api/Alugueis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluguel>> GetAluguel(int id)
        {
            var aluguel = await _context.Alugueis
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .ThenInclude(v => v.Fabricante)
                .FirstOrDefaultAsync(a => a.AluguelId == id);

            if (aluguel == null)
            {
                return NotFound();
            }

            return aluguel;
        }

        // PUT: api/Alugueis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluguel(int id, Aluguel aluguel)
        {
            if (id != aluguel.AluguelId)
            {
                return BadRequest();
            }

            _context.Entry(aluguel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(id))
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

        // POST: api/Alugueis
        [HttpPost]
        public async Task<ActionResult<Aluguel>> PostAluguel(Aluguel aluguel)
        {
            _context.Alugueis.Add(aluguel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluguel", new { id = aluguel.AluguelId }, aluguel);
        }

        // DELETE: api/Alugueis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluguel(int id)
        {
            var aluguel = await _context.Alugueis.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            _context.Alugueis.Remove(aluguel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // --- FILTROS ESPECIAIS ---

        // FILTRO 4: Buscar aluguéis ativos (que ainda não foram devolvidos) (usa WHERE e JOIN)
        [HttpGet("ativos")]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAlugueisAtivos()
        {
            var alugueis = await _context.Alugueis
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .Where(a => a.DataDevolucao == null)
                .ToListAsync();
            
            return Ok(alugueis);
        }
        
        // FILTRO 5: Buscar histórico de aluguéis de um cliente específico (usa WHERE e JOIN)
        [HttpGet("por-cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAlugueisPorCliente(int clienteId)
        {
            var alugueis = await _context.Alugueis
                .Include(a => a.Veiculo.Fabricante)
                .Where(a => a.ClienteId == clienteId)
                .OrderByDescending(a => a.DataInicio)
                .ToListAsync();
            
            return Ok(alugueis);
        }

        private bool AluguelExists(int id)
        {
            return _context.Alugueis.Any(e => e.AluguelId == id);
        }
    }
}
