using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaCys2
{
    public partial class FileLockr : Form
    {
        private string[] clavesRSA;
        private ApiService apiService = new ApiService("http://localhost:8080/");
        public FileLockr()
        {
            InitializeComponent();
            this.BackColor = SystemColors.GradientInactiveCaption;
            panelListado.Visible = false;
            panelAcceso.Visible = true;
            panelCifrado.Visible = false;
            panelUsuarios.Visible = false;

            string path1 = (@"../../../../../archivos");
            string path2 = (@"../../../../../archivos_descomprimidos");
            string path3 = (@"../../../../../claves");


            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);

            if (!Directory.Exists(path2))
                Directory.CreateDirectory(path2);

            if (!Directory.Exists(path3))
                Directory.CreateDirectory(path3);
           


        }


        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            compressAndEncrypt decryptAes = new compressAndEncrypt();
            string user = textBoxUser.Text;
            if (listaArchivos.SelectedItem != null)
            {
                string filePath = "../../../../../archivos/" + user + "/" + listaArchivos.SelectedItem.ToString() + "_encrypted.zip";
                string baseFileName = Path.GetFileNameWithoutExtension(filePath).Replace("_encrypted", "");
                //baseFileName = "../../../../"+;
                // Leer el archivo encriptado como bytes
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("No se encontró el archivo en el dispositivo.");
                    return;
                }
                byte[] encryptedFile = File.ReadAllBytes(filePath);

                // Buscar el archivo de claves que coincide con el nombre base
                string keysFilePath = Path.Combine(@"../../../../../claves/" + user + "/", $"{baseFileName}_keys.zip");
               
                if (!File.Exists(keysFilePath))
                {
                    MessageBox.Show("No se encontró el archivo de claves correspondiente.");
                    return;
                }

                // Leer y descomprimir las claves del archivo ZIP
                byte[] compressedKeys = File.ReadAllBytes(keysFilePath);
                Dictionary<string, byte[]> keys = decryptAes.DecompressFiles(compressedKeys);

                if (keys == null || !keys.ContainsKey("Kfile") || !keys.ContainsKey("IV"))
                {
                    MessageBox.Show("Error al leer las claves comprimidas.");
                    return;
                }

                // Obtener la clave (Kfile) y el IV desde el archivo comprimido
                byte[] key = keys["Kfile"];
                byte[] iv = keys["IV"];

                key = decryptAes.DecryptAesKeyWithRsa(key, clavesRSA[1]);
                iv = decryptAes.DecryptAesKeyWithRsa(iv, clavesRSA[1]);
                // Desencriptar el archivo
                byte[] decryptedFile = decryptAes.DecryptAes(encryptedFile, key, iv);

                // Descomprimir el archivo desencriptado
                Dictionary<string, byte[]> decompressedFiles = decryptAes.DecompressFiles(decryptedFile);

                // Guardar los archivos descomprimidos
                string outputPath = @"../../../../../archivos_descomprimidos/" + user + "/";
                if (!Directory.Exists(outputPath))
                    Directory.CreateDirectory(outputPath);

                foreach (var file in decompressedFiles)
                {
                    File.WriteAllBytes(Path.Combine(outputPath, file.Key), file.Value);
                }
                outputPath = Path.GetFullPath(@"../../../../../archivos_descomprimidos/" + user + "/");
                Process.Start("explorer.exe", outputPath);
            }
        }

        private async Task<bool> checkUser(string user, string passLogin)
        {
            User usuario = await this.apiService.GetUser(user);
            return CryptographicOperations.FixedTimeEquals(
                                                            Convert.FromBase64String(usuario.clave), 
                                                            Convert.FromBase64String(passLogin)
                                                           );
        }

        static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // Tamaño del salt (128 bits)
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        static byte[] GenerateHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); // Tamaño del hash (256 bits)
            }
        }

        static string ComputeSha256Hash(string input)
        {
            // Convertir el string en un arreglo de bytes
            byte[] bytes = Encoding.UTF8.GetBytes(input);

            // Crear instancia de SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Generar el hash
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convertir el arreglo de bytes a un string hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        static (string, string) DividirPorMitad(string input)
        {
            // Calcular el punto medio
            int longitud = input.Length;
            int mitad = longitud / 2;

            // Obtener las dos mitades
            string primeraMitad = input.Substring(0, mitad);
            string segundaMitad = input.Substring(mitad);

            return (primeraMitad, segundaMitad);
        }


        private void buttonAcceder_Click(object sender, EventArgs e)
        {

            string passUsuario = textBoxPassword.Text;
            string user = textBoxUser.Text;
            Console.WriteLine($"Usuario login{user}");
            Console.WriteLine($"Contraseña{passUsuario}");
            compressAndEncrypt compressAndEncrypt = new compressAndEncrypt();
            string publicKey, privateKey;

            passUsuario = ComputeSha256Hash(passUsuario);

            (string kdatos, string passLogin) = DividirPorMitad(passUsuario);

            byte[] salt = GenerateSalt();
            byte[] hash = GenerateHash(passLogin, salt);

            passLogin = Convert.ToBase64String(hash);
            string sal = Convert.ToBase64String(salt);

            clavesRSA = new string[2];
            if (passUsuario == "" || user == "")
            {
                MessageBox.Show("Complete los campos de inicio de sesión.");
                panelListado.Visible = false;
                panelAcceso.Visible = true;
                panelCifrado.Visible = false;
                return;
            }
            bool check = checkUser(user, passLogin).Result;
            if (!check)
            {
                /*Generar clave publica y privada*/
                compressAndEncrypt.GenerateRsaKeys(out publicKey, out privateKey);
                clavesRSA = new string[2] { publicKey, privateKey };

                byte[] clavePublica = Encoding.UTF8.GetBytes(publicKey);
                clavePublica = compressAndEncrypt.CompressFiles(new Dictionary<string, byte[]> { { "publicKey", clavePublica } });

                Directory.CreateDirectory(@"../../../../../claves/" + user);
                File.WriteAllBytes(@"../../../../../claves/" + user + "/publicKey" + ".zip", clavePublica);
                string relativePath = Path.Combine("..", "claves", user, "publicKey.zip");

                byte[] clavePrivada = compressAndEncrypt.EncryptPrivateKeyWithAes(clavesRSA[1], kdatos);
                clavePrivada = compressAndEncrypt.CompressFiles(new Dictionary<string, byte[]> { { "privateKey", clavePrivada } });
                File.WriteAllBytes(@"../../../../../claves/" + user + "/privateKey" + ".zip", clavePrivada);
                MessageBox.Show("Claves generadas con éxito.");

                if (login.Token == null)
                {
                    LoginResponse registro = await apiService.CreaUser(user, passUsuario, clavePublica);

                }
            }
            else
            {
                clavesRSA[0] = Encoding.UTF8.GetString(compressAndEncrypt.DecompressFiles(File.ReadAllBytes(@"../../../../../claves/" + user + "/publicKey.zip"))["publicKey"]);
                byte[] privateKeyBytes = File.ReadAllBytes(@"../../../../../claves/" + user + "/privateKey.zip");
                Dictionary<string, byte[]> privateKeyDict = compressAndEncrypt.DecompressFiles(privateKeyBytes);
                try
                {
                    clavesRSA[1] = compressAndEncrypt.DecryptPrivateKeyWithAes(privateKeyDict["privateKey"], kdatos);
                    panelListado.Visible = true;
                    panelAcceso.Visible = false;
                    panelCifrado.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Contraseña incorrecta.");
                    panelListado.Visible = false;
                    panelAcceso.Visible = true;
                    panelCifrado.Visible = false;
                    return;
                }


            }

            listarArchivos();

        }

        private void buttonCifrar_Click(object sender, EventArgs e)
        {
            panelListado.Visible = false;
            panelAcceso.Visible = false;
            panelCifrado.Visible = true;
            listaExaminados.Items.Clear();

        }

        private void buttonExaminar_Click(object sender, EventArgs e)
        {
            // Crear un diálogo para seleccionar archivos
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,  // Permitir seleccionar varios archivos
                Title = "Seleccionar archivos para comprimir y cifrar"
            };

            // Si el usuario selecciona archivos
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Agregar los archivos seleccionados al ListBox
                foreach (string filePath in openFileDialog.FileNames)
                {
                    listaExaminados.Items.Add(filePath);

                }

                MessageBox.Show("Archivos seleccionados. Presiona 'Confirmar' para cifrarlos.");
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelListado_Paint(object sender, PaintEventArgs e)
        {

        }

        // Evento cuando el usuario hace clic en el botón "Confirmar"
        private async void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (listaExaminados.Items.Count > 0)
            {
                string user = textBoxUser.Text;
                string nombreArchivo = textBoxNombreArchivo.Text;
                compressAndEncrypt compressAndEncrypt = new compressAndEncrypt();

                // Crear un diccionario para almacenar los archivos y su contenido
                Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();

                // Recorrer los archivos del ListBox
                foreach (var item in listaExaminados.Items)
                {
                    string filePath = item.ToString();
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string fileName = Path.GetFileName(filePath);  // Obtener solo el nombre del archivo
                    files.Add(fileName, fileBytes);
                }

                // Generar una clave y IV aleatorios
                byte[] key = new byte[16]; // Kfile 
                RandomNumberGenerator.Fill(key); // Generar 128 bytes aleatorios para la clave

                byte[] iv = new byte[16]; // Iv
                RandomNumberGenerator.Fill(iv); // Generar 16 bytes aleatorios para el IV

                // Crear el diccionario que contendrá la clave (Kfile) y el IV
                Dictionary<string, byte[]> claves = new Dictionary<string, byte[]>()
                {
                    { "Kfile", key },
                    { "IV", iv }
                };

                // Crear un nombre único basado en la fecha y hora actual
                Directory.CreateDirectory(@"../../../../../claves/" + user);
                string uniqueFileName = nombreArchivo + $"_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}";
                string keysFilePath = Path.Combine(@"../../../../../claves/" + user + "/", $"{uniqueFileName}_keys.zip");

                // Comprimir y cifrar los archivos seleccionados
                byte[] encryptedZip = compressAndEncrypt.CompressAndEncryptFiles(files, key, iv);

                // Guardar el archivo ZIP cifrado en una ubicación deseada con el mismo nombre único
                Directory.CreateDirectory(@"../../../../../archivos/" + user);
                string encryptedFilePath = Path.Combine(@"../../../../../archivos/" + user + "/", $"{uniqueFileName}_encrypted.zip");
                File.WriteAllBytes(encryptedFilePath, encryptedZip);

                MessageBox.Show($"Archivos comprimidos y cifrados con éxito.\nGuardado en: {encryptedFilePath}\nClaves guardadas en: {keysFilePath}");

                // Comprimir y encriptar las claves
                claves["Kfile"] = compressAndEncrypt.EncryptAesKeyWithRsa(claves["Kfile"], clavesRSA[0]);
                claves["IV"] = compressAndEncrypt.EncryptAesKeyWithRsa(claves["IV"], clavesRSA[0]);
                byte[] compressedKeys = compressAndEncrypt.CompressFiles(claves);
                string kfile = Encoding.UTF8.GetString(claves["Kfile"]);
                string ivString = Encoding.UTF8.GetString(claves["IV"]);
                // Guardar el archivo comprimido (ZIP) en el sistema de archivos con el nombre único

                File.WriteAllBytes(keysFilePath, compressedKeys);
                int idUsuario = await apiService.GetUserId(user);
                Console.WriteLine("idUsuario" + idUsuario);
                Console.WriteLine("ruta: " + encryptedFilePath);
                Console.WriteLine("iv: "+ ivString);
                Console.WriteLine("kfile: " + kfile);
                apiService.CreaFichero(encryptedFilePath, idUsuario,keysFilePath);

                // Limpiar el ListBox después de confirmar
                listaArchivos.Items.Clear();
                panelListado.Visible = true;
                panelAcceso.Visible = false;
                panelCifrado.Visible = false;


                listarArchivos();

            }
            else
            {
                MessageBox.Show("No se han seleccionado archivos. Por favor, selecciona los archivos antes de confirmar.");
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            panelListado.Visible = true;
            panelAcceso.Visible = false;
            panelCifrado.Visible = false;
            panelUsuarios.Visible = false;
            listarArchivos();
        }
        private async void listarArchivos()
        {
            listaArchivos.Items.Clear();
            string user = textBoxUser.Text;
            int idUser= await apiService.GetUserId(user);
            Console.WriteLine("usuario id " + idUser);
            List<Fichero>  fnuevos = await apiService.getFicheros(idUser);
            string folderPath = @"../../../../../archivos/" + user + "/";
            foreach (Fichero item in fnuevos)
            {
                var ruta = item.ruta;
                ruta.Replace("../../../../../archivos/" + user + "/", "");

                ruta.Replace("_encrypted.zip", "");
                Console.WriteLine(item);
            }
            listaArchivos.Items.AddRange(fnuevos.Select(file => Path.GetFileName(file.ruta).Substring(0, Path.GetFileName(file.ruta).Length - "_encrypted.zip".Length)).ToArray());
        }

        private async void btn_Compartir(object sender, EventArgs e)
        {
            panelUsuarios.Visible = true;
            panelListado.Visible = false;
            panelAcceso.Visible = false;
            panelCifrado.Visible = false;
            List<User> usuarios = await apiService.GetUsersAsync();
            listUsuarios.Items.Clear();
            Console.WriteLine("Usuarios obtenidos");
            foreach (var item in usuarios)
            {
                if(item.nombre != textBoxUser.Text)
                    listUsuarios.Items.Add(item.nombre);
                Console.WriteLine(item.nombre);
            }
        }

        private async void compartir(object sender, EventArgs e)
        {
           
           
        }
    }
}
