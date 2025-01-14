using ElectroPoint.Models;
using ElectroPoint.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectroPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EletronicosController : ControllerBase
    {
        private readonly EletroPointDbContext _context;

        public EletronicosController(EletroPointDbContext context)
        {
            _context = context;
        }

        // GET: api/eletronicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EletronicosModel>>> GetEletronicos()
        {
            try
            {
                var eletrônicos = await _context.Electronics.ToListAsync();
                return Ok(eletrônicos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao recuperar os eletrônicos: {ex.Message}");
            }
        }

        // GET: api/eletronicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EletronicosModel>> GetEletronico(int id)
        {
            try
            {
                var eletronico = await _context.Electronics.FindAsync(id);

                if (eletronico == null)
                {
                    return NotFound();
                }

                return Ok(eletronico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao recuperar o eletrônico: {ex.Message}");
            }
        }

        // POST: api/eletronicos
        [HttpPost]
        public async Task<ActionResult<EletronicosModel>> PostEletronico([FromBody] EletronicosModel eletronico)
        {
            if (eletronico == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                _context.Electronics.Add(eletronico);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEletronico), new { id = eletronico.Id_eletronicos }, eletronico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar o eletrônico: {ex.Message}");
            }
        }

        // PUT: api/eletronicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEletronico(int id, [FromBody] EletronicosModel eletronico)
        {
            if (id != eletronico.Id_eletronicos)
            {
                return BadRequest("IDs não correspondem.");
            }

            _context.Entry(eletronico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EletronicoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Erro de concorrência ao atualizar o eletrônico.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o eletrônico: {ex.Message}");
            }
        }

        // DELETE: api/eletronicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEletronico(int id)
        {
            try
            {
                var eletronico = await _context.Electronics.FindAsync(id);
                if (eletronico == null)
                {
                    return NotFound();
                }

                _context.Electronics.Remove(eletronico);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir o eletrônico: {ex.Message}");
            }
        }

        private bool EletronicoExists(int id)
        {
            return _context.Electronics.Any(e => e.Id_eletronicos == id);
        }
    }
}
