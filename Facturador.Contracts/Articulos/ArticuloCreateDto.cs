using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador.Contracts.Articulos
{
    public class ArticuloCreateDto
    {
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
