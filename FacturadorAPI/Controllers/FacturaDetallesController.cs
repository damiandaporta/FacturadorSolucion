using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacturadorDomain.Repositories;
using FacturadorDomain.Entities;

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaDetallesController : ControllerBase
    {
        private readonly IFacturaDetalleRepository _repository;

        public FacturaDetallesController(IFacturaDetalleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDetalle>>> GetFacturaDetalles()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaDetalle>> GetFacturaDetalle(int id)
        {
            var facturaDetalle = await _repository.GetByIdAsync(id);

            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return Ok(facturaDetalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaDetalle(int id, FacturaDetalle facturaDetalle)
        {
            var updated = await _repository.UpdateAsync(id, facturaDetalle);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<FacturaDetalle>> PostFacturaDetalle(FacturaDetalle facturaDetalle)
        {
            var created = await _repository.AddAsync(facturaDetalle);
            return CreatedAtAction(nameof(GetFacturaDetalle), new { id = created.Fact_Dtl_ID }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaDetalle(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
