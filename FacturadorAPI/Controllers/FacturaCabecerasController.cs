using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using FacturadorDomain.Repositories;
using FacturadorDomain.Entities;

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaCabecerasController : ControllerBase
    {
        private readonly IFacturaCabeceraRepository _repository;

        public FacturaCabecerasController(IFacturaCabeceraRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaCabecera>>> GetFacturaCabeceras()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaCabecera>> GetFacturaCabecera(int id)
        {
            var facturaCabecera = await _repository.GetByIdAsync(id);

            if (facturaCabecera == null)
            {
                return NotFound();
            }

            return Ok(facturaCabecera);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaCabecera(int id, FacturaCabecera facturaCabecera)
        {
            var updated = await _repository.UpdateAsync(id, facturaCabecera);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<FacturaCabecera>> PostFacturaCabecera(FacturaCabecera facturaCabecera)
        {
            var created = await _repository.AddAsync(facturaCabecera);
            return CreatedAtAction(nameof(GetFacturaCabecera), new { id = created.Fact_ID }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaCabecera(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
