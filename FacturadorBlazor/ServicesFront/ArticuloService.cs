using FacturadorDomain.Entities;

    public class ArticuloService
    {
        private readonly HttpClient _httpClient;

        public ArticuloService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Articulo>> GetArticulosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Articulo>>("api/Articulos");
        }

        public async Task CrearArticuloAsync(Articulo articulo)
        {
            await _httpClient.PostAsJsonAsync("api/Articulos", articulo);
        }

        public async Task EliminarArticuloAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Articulos/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("No se pudo eliminar el cliente");
            }
        }

        public async Task<Articulo?> GetArticuloByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Articulo>($"api/Articulos/{id}");
        }

        public async Task ActualizarArticuloAsync(Articulo articulo)
        {
            await _httpClient.PutAsJsonAsync($"api/Articulos/{articulo.Art_ID}", articulo);
        }
    }

