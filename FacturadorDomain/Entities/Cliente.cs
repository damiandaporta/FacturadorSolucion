using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturadorDomain.Entities
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Cli_ID { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string CUIT { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Deshabilitado { get; set; }
    }
}
