using EletroPoint.Models;
using EletroPoint.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EletroPoint.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EletronicosModel>>> GetEletronicos()
        {
            try
            {
                var eletronicos = await _context.Eletronicos.ToListAsync();
                return Ok(eletronicos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao recuperar os eletrônicos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EletronicosModel>> GetEletronico(int id)
        {
            try
            {
                var eletronico = await _context.Eletronicos.FindAsync(id);

                if (eletronico == null)
                {
                    return NotFound("Eletrônico não encontrado.");
                }

                return Ok(eletronico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao recuperar o eletrônico: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EletronicosModel>> PostEletronico([FromBody] EletronicosModel eletronico)
        {
            if (eletronico == null || string.IsNullOrWhiteSpace(eletronico.Nome))
            {
                return BadRequest("Dados inválidos. Verifique as informações fornecidas.");
            }

            try
            {
                _context.Eletronicos.Add(eletronico);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEletronico), new { id = eletronico.Id_eletronicos }, eletronico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar o eletrônico: {ex.Message}");
            }
        }

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
                    return NotFound("Eletrônico não encontrado.");
                }
                return StatusCode(500, "Erro de concorrência ao atualizar o eletrônico.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o eletrônico: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEletronico(int id)
        {
            try
            {
                var eletronico = await _context.Eletronicos.FindAsync(id);
                if (eletronico == null)
                {
                    return NotFound("Eletrônico não encontrado.");
                }

                _context.Eletronicos.Remove(eletronico);
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
            return _context.Eletronicos.Any(e => e.Id_eletronicos == id);
        }
    }
}
