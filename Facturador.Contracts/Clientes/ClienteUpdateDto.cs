using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador.Contracts.Clientes
{
    public class ClienteUpdateDto
    {
        public int Cli_ID { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string CUIT { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
