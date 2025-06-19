using Microsoft.AspNetCore.Mvc;

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasReportesController : ControllerBase
    {
        private readonly IFacturaRepository _repository;

        public FacturasReportesController(IFacturaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("total-facturado-mes-anterior")]
        public async Task<IActionResult> GetTotalFacturadoMesAnterior()
        {
            var total = await _repository.ObtenerTotalFacturadoMesAnterior();
            return Ok(total);
        }

        [HttpGet("facturas-cuit-termina-en-8")]
        public async Task<IActionResult> GetFacturasClientesCuit8()
        {
            var lista = await _repository.ObtenerFacturasClientesCuit8();
            return Ok(lista);
        }
    }
}
