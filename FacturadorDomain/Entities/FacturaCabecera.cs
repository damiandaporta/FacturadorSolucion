using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturadorDomain.Entities
{
    [Table("Factura_Cabecera")]
    public class FacturaCabecera
    {
        [Key]
        public int Fact_ID { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Cli_ID { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
