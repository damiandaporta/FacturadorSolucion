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
    public class FacturaCabeceraRepository : IFacturaCabeceraRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaCabeceraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaCabecera>> GetAllAsync()
        {
            return await _context.FacturaCabecera.ToListAsync();
        }

        public async Task<FacturaCabecera?> GetByIdAsync(int id)
        {
            return await _context.FacturaCabecera.FindAsync(id);
        }

        public async Task<FacturaCabecera> AddAsync(FacturaCabecera facturaCabecera)
        {
            _context.FacturaCabecera.Add(facturaCabecera);
            await _context.SaveChangesAsync();
            return facturaCabecera;
        }

        public async Task<bool> UpdateAsync(int id, FacturaCabecera facturaCabecera)
        {
            if (id != facturaCabecera.Fact_ID)
                return false;

            _context.Entry(facturaCabecera).State = EntityState.Modified;

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
            var facturaCabecera = await _context.FacturaCabecera.FindAsync(id);
            if (facturaCabecera == null)
                return false;

            _context.FacturaCabecera.Remove(facturaCabecera);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.FacturaCabecera.AnyAsync(e => e.Fact_ID == id);
        }
    }
}