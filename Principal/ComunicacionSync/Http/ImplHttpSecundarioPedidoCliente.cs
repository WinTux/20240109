using Principal.DTO;
using System.Text;
using System.Text.Json;

namespace Principal.ComunicacionSync.Http
{
    public class ImplHttpSecundarioPedidoCliente : ISecundarioPedidoCliente
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public ImplHttpSecundarioPedidoCliente(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task ComunicarseConSecundario(PlatoReadDTO plato)
        {
            StringContent cuerpoHttp = new StringContent(JsonSerializer.Serialize(plato), Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync($"{_configuration["SecundarioService"]}/api/Pedido", cuerpoHttp);
            if (respuesta.IsSuccessStatusCode)
                Console.WriteLine("Envío de POST sincronizado hacia el servicio Secundario tuvo exito.");
            else
                Console.WriteLine("Envío de POST sincronizado hacia el servicio Secundario NO tuvo exito.");
        }
    }
}
