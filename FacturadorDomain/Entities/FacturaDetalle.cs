using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturadorDomain.Entities
{
    [Table("Factura_Detalle")]
    public class FacturaDetalle
    {
        [Key]
        public int Fact_Dtl_ID { get; set; }
        public int Fact_ID { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Art_ID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Monto { get; set; }
    }
}
