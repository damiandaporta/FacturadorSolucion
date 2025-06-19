
using FacturadorDomain.Entities;

public class FacturaCabeceraService
    {
    private readonly HttpClient _httpClient;

    public FacturaCabeceraService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FacturaCabecera>> GetFacturaCabecerasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<FacturaCabecera>>("api/FacturaCabeceras");
    }

    public async Task CrearFacturaCabecerasAsync(FacturaCabecera facturaCabecera)
    {
        await _httpClient.PostAsJsonAsync("api/FacturaCabeceras", facturaCabecera);
    }

    public async Task EliminarFacturaCabeceraAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/FacturaCabeceras/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("No se pudo eliminar la factura Cabecera");
        }
    }

    public async Task<FacturaCabecera?> GetFacturaCabeceraByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<FacturaCabecera>($"api/FacturaCabeceras/{id}");
    }

    public async Task ActualizarFacturaCabeceraAsync(FacturaCabecera facturaCabecera)
    {
        await _httpClient.PutAsJsonAsync($"api/FacturaCabeceras/{facturaCabecera.Fact_ID}", facturaCabecera);
    }
}

