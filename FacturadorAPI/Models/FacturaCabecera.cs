using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FacturadorAPI.Models;

[Table("Factura_Cabecera")]
public partial class FacturaCabecera
{
    [Key]
    [Column("Fact_ID")]
    public int FactId { get; set; }

    public DateOnly FechaAlta { get; set; }

    [Column("Cli_ID")]
    public int CliId { get; set; }

    [StringLength(50)]
    public string Estado { get; set; } = null!;
}
