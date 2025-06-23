using Microsoft.AspNetCore.Mvc;
using FacturadorInfrastructure.Context;
using FacturadorDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacturadorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("facturas-monto-total")]
        public async Task<ActionResult<IEnumerable<FacturaConMontoTotal>>> GetFacturasConMontoTotal()
        {
            var result = await _context.Set<FacturaConMontoTotal>().ToListAsync();
            return Ok(result);
        }

        [HttpGet("facturas-cliente")]
        public async Task<ActionResult<IEnumerable<FacturaConCliente>>> GetFacturasConCliente()
        {
            var result = await _context.Set<FacturaConCliente>().ToListAsync();
            return Ok(result);
        }
    }
}
