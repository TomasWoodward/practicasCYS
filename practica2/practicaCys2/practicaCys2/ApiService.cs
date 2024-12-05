using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.VisualBasic.ApplicationServices;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;
    private string _authToken;
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

            // Deserializar la respuesta en el tipo adecuado
            var result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

            return result;
        }
        catch (HttpRequestException httpEx)
        {
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

        var response = await PostAsync<object, LoginResponse>("auth/login", loginData);

        // Manejar el resultado basado en el campo Status
        switch (response.Status)
        {
            case "success":
                break;
            case "error":
                break;
            default:
                throw new Exception("Respuesta inesperada del servidor.");
        }

        return response;
    }

    public async Task<LoginResponse> CreaUser(string username, string password, string salt,byte[] publicKey, byte[] privateKey)
    {
        var registerData = new
        {
            nombre = username,
            clave = password,
            salt = salt,
            publicKey = publicKey,
            privateKey = privateKey
        };

        // Usar el método POST para enviar las credenciales
        return await PostAsync<object, LoginResponse>("auth/register", registerData);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        try
        {
            // Llamar al método GET para obtener la lista de usuarios
            return await GetAsync<List<User>>("usuarios");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la lista de usuarios: {ex.Message}");
        }
    }

    public void SetAuthToken(string token)
    {
        _authToken = token;
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<List<Fichero>> GetFicherosAsync()
    {
        try
        {
            // Llamar al método GET para obtener la lista de usuarios
            return await GetAsync<List<Fichero>>("ficheros");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la lista de ficheros: {ex.Message}");
        }
    }

    public async Task<Fichero> GetFicheroAsync(int id)
    {
        try
        {
            // Llamar al método GET para obtener la lista de usuarios
            return await GetAsync<Fichero>($"ficheros/{id}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la lista de ficheros: {ex.Message}");
        }
    }

    public async Task<Fichero> CreaFichero(string ruta, int usuario, string claves)
    {
        var registerData = new
        {
            ruta = ruta,
            usuario = usuario,
            claves=claves
        };
        return await PostAsync<object, Fichero>("ficheros", registerData);
    }

    public async Task<int> GetUserId(string username)
    {
        try
        {
            // Llamar al método GET para obtener la lista de usuarios
            User usuario = await GetAsync<User>($"usuario/{username}");
            
            return usuario.idUsuario;

        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el usuario: {ex.Message}");
        }
    }

    public async Task<User> GetUser(int id)
    {
        try
        {
            User usuario = await GetAsync<User>($"usuarios/{id}");
            return usuario;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Fichero>> getFicheros(int usuario)
    {
        try
        {

            List<Fichero> ficheros = await GetAsync<List<Fichero>>($"ficheros");
            var ficherosFiltrados = ficheros.Where(f => f.usuario == usuario).ToList();

            return ficherosFiltrados;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la lista de ficheros: {ex.Message}");
        }
    }
}


public class LoginResponse
{
    public string Status { get; set; } // 'success' o 'error'
    public string Message { get; set; } // Mensaje descriptivo ('Usuario no encontrado', 'Contraseña incorrecta')
    public string Token { get; set; } // Token si el login es exitoso
}

public class User
{
    public int idUsuario { get; set; }
    public string nombre { get; set; }

    public string clave { get; set; }

    public string salt { get; set; }
    public Key1 publicKey { get; set; }
    public Key1 privateKey { get; set; }
}


public class Key1
{
    public string Type { get; set; }
    public string Key { get; set; }
}

public class Fichero
{
    public string ruta { get; set; }
    public int usuario { get; set; }
    public string claves { get; set; }
}