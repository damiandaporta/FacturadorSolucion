public class FacturaConProductoMasVendidoDto
{
    public int Fact_ID { get; set; }
    public DateTime FechaAlta { get; set; }
    public int Cli_ID { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int? ProductoMasVendidoID { get; set; }
    public string? ProductoMasVendidoNombre { get; set; }
}
