using AtlantidaApplication.Models;
using System.Text;
using System.Text.Json;

namespace AtlantidaApplication.API
{
    public class AtlantidaAPI
    {
        string? UriAPI = null;

        public AtlantidaAPI(IConfiguration config)
        {
            //UriAPI = config["UrlApi"];
            UriAPI = "https://localhost:44341";
        }

        public async Task<HttpResponseMessage> GetAgencias (AGENCIA model)
        {
            using (HttpClient client = new HttpClient())
            {
                // Configurar la URL base de la API (si es necesario)
                client.BaseAddress = new Uri(UriAPI);
                HttpResponseMessage response = null;

                try
                {
                    string json = JsonSerializer.Serialize(model);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync("/AGENCIA/api/Get", content);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si el estado HTTP es un código de error

                    // Leer el contenido de la respuesta como un string
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    return response;
                }

                return response;
            }
        }

        public async Task<HttpResponseMessage> GetTarjetas(CLIENTEXPRODUCTO model)
        {
            using (HttpClient client = new HttpClient())
            {
                // Configurar la URL base de la API (si es necesario)
                client.BaseAddress = new Uri(UriAPI);
                HttpResponseMessage response = null;

                try
                {
                    string json = JsonSerializer.Serialize(model);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync("/CLIENTEXPRODUCTO/api/Get", content);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si el estado HTTP es un código de error

                    // Leer el contenido de la respuesta como un string
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    return response;
                }

                return response;
            }
        }

        public async Task<HttpResponseMessage> GetProductos(PRODUCTO model)
        {
            using (HttpClient client = new HttpClient())
            {
                // Configurar la URL base de la API (si es necesario)
                client.BaseAddress = new Uri(UriAPI);
                HttpResponseMessage response = null;

                try
                {
                    string json = JsonSerializer.Serialize(model);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync("/PRODUCTO/api/Get", content);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si el estado HTTP es un código de error

                    // Leer el contenido de la respuesta como un string
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    return response;
                }

                return response;
            }
        }

        public async Task<HttpResponseMessage> GetClientes(PERSONA model)
        {
            using (HttpClient client = new HttpClient())
            {
                // Configurar la URL base de la API (si es necesario)
                client.BaseAddress = new Uri(UriAPI);
                HttpResponseMessage response = null;

                try
                {
                    string json = JsonSerializer.Serialize(model);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync("/PERSONA/api/Get", content);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si el estado HTTP es un código de error

                    // Leer el contenido de la respuesta como un string
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    return response;
                }

                return response;
            }
        }
    }
}
