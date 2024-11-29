using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;

    // Constructor
    public ApiService(string baseAddress)
    {
        _httpClient = new HttpClient();
        _baseAddress = baseAddress.TrimEnd('/');
    }


    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest requestData)
    {
        try
        {
            // Convertir la solicitud a JSON
            var jsonContent = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Realizar la solicitud POST
            var response = await _httpClient.PostAsync($"{_baseAddress}/{endpoint}", content);

            // Verificar si la respuesta es exitosa
            response.EnsureSuccessStatusCode();

            // Leer y deserializar la respuesta
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse); // Imprimir respuesta para depuración

            // Deserializar la respuesta en el tipo adecuado
            var result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"{_baseAddress}/{endpoint}");
            Console.WriteLine($"Detalles del error HTTP: {httpEx.Message}");
            throw new Exception($"Error al realizar la solicitud: {httpEx.Message}", httpEx);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al realizar la solicitud POST: {ex.Message}");
        }
    }
    // Método genérico para realizar solicitudes GET
    public async Task<TResponse> GetAsync<TResponse>(string endpoint)
    {
        try
        {
            // Realizar la solicitud GET
            var response = await _httpClient.GetAsync($"{_baseAddress}/{endpoint}");

            // Verificar si la respuesta es exitosa
            response.EnsureSuccessStatusCode();

            // Leer y deserializar la respuesta
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al realizar la solicitud GET: {ex.Message}");
        }
    }


    public async Task<LoginResponse> LoginAsync(string username, string password)
    {
        var loginData = new
        {
            nombre = username,
            clave = password
        };

        // Usar el método POST para enviar las credenciales
        return await PostAsync<object, LoginResponse>("auth/login", loginData);
    }

    public async Task<LoginResponse> CreaUser(string username, string password,byte[] publicKey)
    {
        var registerData = new
        {
            nombre = username,
            clave = password,
            publicKey = publicKey
        };

        // Usar el método POST para enviar las credenciales
        return await PostAsync<object, LoginResponse>("auth/register", registerData);
    }
}


public class LoginResponse
{
    public string Token { get; set; }
    
}