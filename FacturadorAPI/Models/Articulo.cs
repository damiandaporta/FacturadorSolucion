using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FacturadorAPI.Models;

[Table("Articulo")]
public partial class Articulo
{
    [Key]
    [Column("Art_ID")]
    public int ArtId { get; set; }

    [StringLength(255)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }
}
