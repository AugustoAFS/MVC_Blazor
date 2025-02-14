﻿using EletroPoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EletroPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly EletroPointDbContext _context;

        public AdminController(EletroPointDbContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminModel>>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        // GET api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminModel>> GetAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
                return NotFound();

            return admin;
        }

        // POST api/Admin
        [HttpPost]
        public async Task<ActionResult<AdminModel>> PostAdmin([FromBody] AdminModel admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id_admin }, admin);
        }

        // PUT api/Admin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, [FromBody] AdminModel admin)
        {
            if (id != admin.Id_admin)
                return BadRequest();

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE api/Admin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
                return NotFound();

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.Id_admin == id);
        }
    }
}
