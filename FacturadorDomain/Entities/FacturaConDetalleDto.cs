public class FacturaConDetalleDto
{
    public int Fact_ID { get; set; }
    public DateTime FechaAlta { get; set; }
    public int Cli_ID { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int Fact_Dtl_ID { get; set; }
    public int Art_ID { get; set; }
    public string NombreProducto { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal Monto { get; set; }
}

