using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FacturadorAPI.Models;

[Table("Factura_Detalle")]
public partial class FacturaDetalle
{
    [Key]
    [Column("Fact_Dtl_ID")]
    public int FactDtlId { get; set; }

    [Column("Fact_ID")]
    public int FactId { get; set; }

    public DateOnly FechaAlta { get; set; }

    [Column("Art_ID")]
    public int ArtId { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Monto { get; set; }
}
