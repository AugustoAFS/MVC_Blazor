using EletroPoint.Models;
using EletroPoint.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EletroPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly EletroPointDbContext _context;

        // Construtor para injeção de dependência do DbContext
        public MarcaController(EletroPointDbContext context)
        {
            _context = context;
        }

        // GET: api/Marca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaModel>>> GetMarcas()
        {
            // Retorna todas as marcas do banco de dados
            return await _context.Marcas.ToListAsync();
        }

        // GET: api/Marca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaModel>> GetMarca(int id)
        {
            // Procura por uma marca específica
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        // POST: api/Marca
        [HttpPost]
        public async Task<ActionResult<MarcaModel>> PostMarca(MarcaModel marca)
        {
            // Adiciona a nova marca ao banco de dados
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            // Retorna a marca criada com o status 201 (Created)
            return CreatedAtAction(nameof(GetMarca), new { id = marca.Id_marca }, marca);
        }

        // PUT: api/Marca/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, MarcaModel marca)
        {
            // Verifica se o ID da marca corresponde ao que está sendo atualizado
            if (id != marca.Id_marca)
            {
                return BadRequest();
            }

            // Marca existe, então atualizamos
            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                // Salva as alterações
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // DELETE: api/Marca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            // Encontra a marca a ser excluída
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            // Remove a marca do banco de dados
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar se a marca existe
        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.Id_marca == id);
        }
    }
}
