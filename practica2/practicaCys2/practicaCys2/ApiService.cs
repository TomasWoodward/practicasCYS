using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace practicaCys2
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string BaseAddress;
        public ApiService()
        {
            // Inicializamos HttpClient con la URL base de tu servidor
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:8080/login") // Cambia esta URL por la de tu servidor
            };

            // Agregamos los headers comunes
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Método para iniciar sesión
        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                // Crear objeto con las credenciales
                var loginData = new
                {
                    username = username,
                    password = password
                };

                // Convertir el objeto a JSON
                var jsonContent = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realizar la petición POST
                HttpResponseMessage response = await _httpClient.PostAsync(BaseAddress, content);

                // Verificar si la respuesta es exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido de la respuesta
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent; // Devuelve la respuesta (token, mensaje, etc.)
                }
                else
                {
                    // Manejar errores de la API
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error en el login: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con el servidor: {ex.Message}");
            }
        }
    }
}
