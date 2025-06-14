using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FacturadorAPI.Models;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    [Column("Cli_ID")]
    public int CliId { get; set; }

    [StringLength(255)]
    public string RazonSocial { get; set; } = null!;

    [Column("CUIT")]
    [StringLength(50)]
    public string Cuit { get; set; } = null!;

    [StringLength(255)]
    public string Direccion { get; set; } = null!;

    public bool Deshabilitado { get; set; }
}
