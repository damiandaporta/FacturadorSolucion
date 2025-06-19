using FacturadorDomain.Entities;

public interface IFacturaRepository
{
    Task<decimal> ObtenerTotalFacturadoMesAnterior();
    Task<List<FacturaCabecera>> ObtenerFacturasClientesCuit8();
}
