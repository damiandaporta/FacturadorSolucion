using System.Net.Http;
using FacturadorDomain.Entities;

public class ClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Cliente>> GetClientesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Cliente>>("api/Clientes");
    }

    public async Task CrearClienteAsync(Cliente cliente)
    {
        await _httpClient.PostAsJsonAsync("api/Clientes", cliente);
    }

    public async Task EliminarClienteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Clientes/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("No se pudo eliminar el cliente");
        }
    }

    public async Task<Cliente?> GetClienteByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Cliente>($"api/Clientes/{id}");
    }

    public async Task ActualizarClienteAsync(Cliente cliente)
    {
        await _httpClient.PutAsJsonAsync($"api/Clientes/{cliente.Cli_ID}", cliente);
    }
}
