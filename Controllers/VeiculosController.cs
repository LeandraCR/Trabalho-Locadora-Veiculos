using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendaVeiculos.Data;
using SistemaVendaVeiculos.Models;

namespace SistemaVendaVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VeiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            // Usa Include para fazer o JOIN com a tabela de Fabricantes
            return await _context.Veiculos.Include(v => v.Fabricante).ToListAsync();
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.Fabricante) // Inclui dados do fabricante
                .FirstOrDefaultAsync(v => v.VeiculoId == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        // PUT: api/Veiculos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.VeiculoId)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
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

        // POST: api/Veiculos
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculo", new { id = veiculo.VeiculoId }, veiculo);
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        // --- FILTROS ESPECIAIS ---

        // FILTRO 1: Buscar veículos por nome do fabricante (usa JOIN)
        [HttpGet("por-fabricante/{nomeFabricante}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculosPorFabricante(string nomeFabricante)
        {
            var veiculos = await _context.Veiculos
                .Include(v => v.Fabricante) // JOIN com Fabricantes
                .Where(v => v.Fabricante != null && v.Fabricante.Nome.Contains(nomeFabricante))
                .ToListAsync();
            
            return Ok(veiculos);
        }

        // FILTRO 2: Buscar veículos com quilometragem abaixo de um valor (usa WHERE)
        [HttpGet("por-quilometragem/{kmMax}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculosPorQuilometragem(double kmMax)
        {
            var veiculos = await _context.Veiculos
                .Include(v => v.Fabricante)
                .Where(v => v.Quilometragem < kmMax)
                .OrderBy(v => v.Quilometragem)
                .ToListAsync();
            
            return Ok(veiculos);
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculos.Any(e => e.VeiculoId == id);
        }
    }
}
