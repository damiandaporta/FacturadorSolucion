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

        [HttpGet("VW-facturas-monto-total")]
        public async Task<ActionResult<IEnumerable<FacturaConMontoTotal>>> GetFacturasConMontoTotal()
        {
            var result = await _context.Set<FacturaConMontoTotal>().ToListAsync();
            return Ok(result);
        }

        [HttpGet("VW-facturas-cliente")]
        public async Task<ActionResult<IEnumerable<FacturaConCliente>>> GetFacturasConCliente()
        {
            var result = await _context.Set<FacturaConCliente>().ToListAsync();
            return Ok(result);
        }

        [HttpGet("SP-facturas-producto-mas-vendido")]
        public async Task<ActionResult<IEnumerable<FacturaConProductoMasVendidoDto>>> GetFacturasProductoMasVendido(
            [FromQuery] DateTime desde,
            [FromQuery] DateTime hasta,
            [FromQuery] int clienteId)
        {
            var result = await _context.Set<FacturaConProductoMasVendidoDto>()
                .FromSqlInterpolated($"EXEC FacturasPorClienteProductoMasVendido {desde}, {hasta}, {clienteId}")
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("SP-facturas-con-detalle")]
        public async Task<ActionResult<IEnumerable<FacturaConDetalleDto>>> GetFacturasConDetalle(
            [FromQuery] DateTime desde,
            [FromQuery] DateTime hasta,
            [FromQuery] int clienteId)
        {
            var result = await _context.Set<FacturaConDetalleDto>()
                .FromSqlInterpolated($"EXEC FacturasPorClienteConDetalle {desde}, {hasta}, {clienteId}")
                .ToListAsync();

            return Ok(result);
        }
    }
}
