using System.ComponentModel.DataAnnotations;

namespace FacturadorBlazor.Models
{
    public class ClienteDto
    {
        public string RazonSocial { get; set; } = string.Empty;
        public string CUIT { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
