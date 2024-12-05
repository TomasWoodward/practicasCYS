using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;

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
            Console.WriteLine($"{_baseAddress}/{endpoint}   " + jsonContent);
            Console.WriteLine(response);
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
            Console.WriteLine("get async: " + jsonResponse);
           
            if (typeof(TResponse) == typeof(User)){
                
                var userResponse = JsonConvert.DeserializeObject<User>(jsonResponse);

                // Si publicKey o privateKey son buffers en formato JSON, asegúrate de convertirlos correctamente a una cadena
                var userJson = JObject.Parse(jsonResponse);  // Usamos JObject para parsear el JSON
                Console.WriteLine("ES ESTE: "+userJson["publicKey"]);
                // Si existe una clave pública en el JSON, asignarla al objeto Key1
                if (userJson["publicKey"] != null)
                {
                    var publicKey = userJson["publicKey"];
                    var data = publicKey["data"];
                    byte[] publicKeyValue = data.ToObject<byte[]>();
                    userResponse.publicKey = new Key1
                    {
                        Type = "RSA", // Puedes cambiar esto si es necesario
                        Key = Convert.ToBase64String(publicKeyValue) // Aquí aseguramos que la clave esté en Base64
                    };
                    Console.WriteLine("Clave pública en get async: " + userResponse.publicKey.Key);
                }

                // Si existe una clave privada en el JSON, asignarla al objeto Key1
                if (userJson["privateKey"] != null)
                {
                    var privateKeyValue = userJson["privateKey"].ToString();
                    userResponse.privateKey = new Key1
                    {
                        Type = "RSA", // Puedes cambiar esto si es necesario
                        Key = Convert.ToBase64String(Convert.FromBase64String(privateKeyValue))  // Aquí aseguramos que la clave esté en Base64
                    };
                }
                return (TResponse)(object)userResponse; // Hacer el cast a TResponse
            }
            else {
                 var userResponse = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                return (TResponse)(object)userResponse; // Hacer el cast a TResponse
            }
            
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

    public async Task<FicheroResponse> CreaFichero(string nombre, byte[] archivo)
    {
        var registerData = new
        {
            nombre = nombre,
            archivo = archivo
        };
        return await PostAsync<object, FicheroResponse>("ficheros", registerData);
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
            Console.WriteLine("clave publica " + usuario.nombre);
            return usuario;

        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async void CompartirFichero(int id,int user,string kfile,string iv)
    {
        var registerData = new
        {
            idFichero = id,
            usuario = user,
            kfile = kfile,
            iv = iv

        };
        await PostAsync<object,FicheroResponse>("compartir", registerData);
    }
    public async Task<List<Fichero>> getFicheros(int usuario)
    {
        try
        {

            List<Fichero> ficheros = await GetAsync<List<Fichero>>($"compartir/{usuario}");

            return ficheros;
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
public class FicheroResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
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
    public int idFichero { get; set; }
    public string nombre { get; set; }
    public byte[] archivo { get; set; }
}

public class Archivo
{
    public string type { get; set; }
    public byte[] data { get; set; }
}