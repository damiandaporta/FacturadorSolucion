using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacturadorAPI.Models;

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaCabecerasController : ControllerBase
    {
        private readonly FacturadorDbContext _context;

        public FacturaCabecerasController(FacturadorDbContext context)
        {
            _context = context;
        }

        // GET: api/FacturaCabeceras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaCabecera>>> GetFacturaCabeceras()
        {
            return await _context.FacturaCabeceras.ToListAsync();
        }

        // GET: api/FacturaCabeceras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaCabecera>> GetFacturaCabecera(int id)
        {
            var facturaCabecera = await _context.FacturaCabeceras.FindAsync(id);

            if (facturaCabecera == null)
            {
                return NotFound();
            }

            return facturaCabecera;
        }

        // PUT: api/FacturaCabeceras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaCabecera(int id, FacturaCabecera facturaCabecera)
        {
            if (id != facturaCabecera.FactId)
            {
                return BadRequest();
            }

            _context.Entry(facturaCabecera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaCabeceraExists(id))
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

        // POST: api/FacturaCabeceras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaCabecera>> PostFacturaCabecera(FacturaCabecera facturaCabecera)
        {
            _context.FacturaCabeceras.Add(facturaCabecera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaCabecera", new { id = facturaCabecera.FactId }, facturaCabecera);
        }

        // DELETE: api/FacturaCabeceras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaCabecera(int id)
        {
            var facturaCabecera = await _context.FacturaCabeceras.FindAsync(id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }

            _context.FacturaCabeceras.Remove(facturaCabecera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaCabeceraExists(int id)
        {
            return _context.FacturaCabeceras.Any(e => e.FactId == id);
        }
    }
}
