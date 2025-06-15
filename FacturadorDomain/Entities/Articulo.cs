using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturadorDomain.Entities
{
    [Table("Articulo")]
    public class Articulo
    {
        [Key]
        public int Art_ID { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
