using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturadorDomain.Entities;

namespace FacturadorDomain.Repositories
{
    public interface IFacturaCabeceraRepository
    {
        Task<IEnumerable<FacturaCabecera>> GetAllAsync();
        Task<FacturaCabecera?> GetByIdAsync(int id);
        Task<FacturaCabecera> AddAsync(FacturaCabecera facturaCabecera);
        Task<bool> UpdateAsync(int id, FacturaCabecera facturaCabecera);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
