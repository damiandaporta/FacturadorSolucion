using System;
using FacturadorDomain.Entities;
using FacturadorDomain.Repositories;
using FacturadorInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class FacturaRepository : IFacturaRepository
{
    private readonly ApplicationDbContext _context;

    public FacturaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> ObtenerTotalFacturadoMesAnterior()
    {
        var fechaInicioMesAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
        var fechaFinMesAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

        var detalles = await _context.FacturaCabecera
            .Where(f => f.FechaAlta >= fechaInicioMesAnterior && f.FechaAlta <= fechaFinMesAnterior)
            .Join(_context.FacturaDetalles,
                  cab => cab.Fact_ID,
                  det => det.Fact_ID,
                  (cab, det) => new { cab.Fact_ID, det.Monto })
            .ToListAsync();

        var totalFacturado = detalles
            .GroupBy(x => x.Fact_ID)
            .Where(g => g.Sum(x => x.Monto) > 10000)
            .Sum(g => g.Sum(x => x.Monto));

        return totalFacturado;
    }


    public async Task<List<FacturaCabecera>> ObtenerFacturasClientesCuit8()
    {
        var clientesIds = await _context.Clientes
            .Where(c => c.CUIT.EndsWith("8"))
            .Select(c => c.Cli_ID)
            .ToListAsync();

        var facturas = await _context.FacturaCabecera
            .Where(f => clientesIds.Contains(f.Cli_ID))
            .ToListAsync();

        return facturas;
    }
}

