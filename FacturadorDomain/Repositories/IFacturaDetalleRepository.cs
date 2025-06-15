using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturadorDomain.Entities;

namespace FacturadorDomain.Repositories
{
    public interface IFacturaDetalleRepository
    {
        Task<IEnumerable<FacturaDetalle>> GetAllAsync();
        Task<FacturaDetalle?> GetByIdAsync(int id);
        Task<FacturaDetalle> AddAsync(FacturaDetalle facturaDetalle);
        Task<bool> UpdateAsync(int id, FacturaDetalle facturaDetalle);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
