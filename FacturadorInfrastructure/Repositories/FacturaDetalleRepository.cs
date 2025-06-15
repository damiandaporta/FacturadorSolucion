using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturadorDomain.Entities;
using FacturadorDomain.Repositories;
using FacturadorInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FacturadorInfrastructure.Repositories
{
    public class FacturaDetalleRepository : IFacturaDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaDetalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaDetalle>> GetAllAsync()
        {
            return await _context.FacturaDetalles.ToListAsync();
        }

        public async Task<FacturaDetalle?> GetByIdAsync(int id)
        {
            return await _context.FacturaDetalles.FindAsync(id);
        }

        public async Task<FacturaDetalle> AddAsync(FacturaDetalle facturaDetalle)
        {
            _context.FacturaDetalles.Add(facturaDetalle);
            await _context.SaveChangesAsync();
            return facturaDetalle;
        }

        public async Task<bool> UpdateAsync(int id, FacturaDetalle facturaDetalle)
        {
            if (id != facturaDetalle.Fact_Dtl_ID)
                return false;

            _context.Entry(facturaDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var facturaDetalle = await _context.FacturaDetalles.FindAsync(id);
            if (facturaDetalle == null)
                return false;

            _context.FacturaDetalles.Remove(facturaDetalle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.FacturaDetalles.AnyAsync(e => e.Fact_Dtl_ID == id);
        }
    }
}
