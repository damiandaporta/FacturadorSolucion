using FacturadorDomain.Entities;

    public class FacturaDetalleService
    {
        private readonly HttpClient _httpClient;

        public FacturaDetalleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FacturaDetalle>> GetFacturaDetallesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<FacturaDetalle>>("api/FacturaDetalles");
        }

        public async Task CrearFacturaDetallesAsync(FacturaDetalle facturaDetalle)
        {
            await _httpClient.PostAsJsonAsync("api/FacturaDetalles", facturaDetalle);
        }

        public async Task EliminarFacturaDetalleAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/FacturaDetalles/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("No se pudo eliminar el detalle de la factura");
            }
        }

        public async Task<FacturaDetalle?> GetFacturaDetalleByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<FacturaDetalle>($"api/FacturaDetalles/{id}");
        }

        public async Task ActualizarFacturaDetalleAsync(FacturaDetalle facturaDetalle)
        {
            await _httpClient.PutAsJsonAsync($"api/FacturaDetalles/{facturaDetalle.Fact_Dtl_ID}", facturaDetalle);
        }
    }
