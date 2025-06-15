using FacturadorDomain.Entities;
using FacturadorDomain.Repositories;
using FacturadorInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FacturadorInfrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateAsync(int id, Cliente cliente)
        {
            if (id != cliente.Cli_ID)
                return false;

            _context.Entry(cliente).State = EntityState.Modified;

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
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Clientes.AnyAsync(e => e.Cli_ID == id);
        }
    }
}
