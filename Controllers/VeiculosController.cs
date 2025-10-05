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

        /// <summary>
        /// Obtém a lista de todos os veículos, incluindo os dados dos seus fabricantes.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.Include(v => v.Fabricante).ToListAsync();
        }

        /// <summary>
        /// Obtém um veículo específico pelo seu ID, incluindo os dados do seu fabricante.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.Fabricante)
                .FirstOrDefaultAsync(v => v.VeiculoId == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        /// <summary>
        /// Atualiza um veículo existente.
        /// </summary>
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

        /// <summary>
        /// Cria um novo veículo.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculo", new { id = veiculo.VeiculoId }, veiculo);
        }

        /// <summary>
        /// Remove um veículo existente.
        /// </summary>
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
        
        /// <summary>
        /// FILTRO 1: Busca veículos por parte do nome do fabricante.
        /// </summary>
        [HttpGet("por-fabricante/{nomeFabricante}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculosPorFabricante(string nomeFabricante)
        {
            var veiculos = await _context.Veiculos
                .Include(v => v.Fabricante)
                .Where(v => v.Fabricante.Nome.Contains(nomeFabricante))
                .ToListAsync();
            
            return Ok(veiculos);
        }

        /// <summary>
        /// FILTRO 2: Busca veículos com quilometragem abaixo de um valor máximo.
        /// </summary>
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