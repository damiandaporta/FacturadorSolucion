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
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo?> GetByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task<Articulo> AddAsync(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
            return articulo;
        }

        public async Task<bool> UpdateAsync(int id, Articulo articulo)
        {
            if (id != articulo.Art_ID)
                return false;

            _context.Entry(articulo).State = EntityState.Modified;

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
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
                return false;

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Articulos.AnyAsync(e => e.Art_ID == id);
        }
    }
}
