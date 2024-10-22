using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace practicaCys2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = SystemColors.GradientInactiveCaption;
            panelListado.Visible = false;
            panelAcceso.Visible = true;
            panelCifrado.Visible = false;


            string folderPath = @"../../../../archivos/";
            string[] files = Directory.GetFiles(folderPath);
            listaArchivos.Items.AddRange(files);


            // Asociar el evento al ListBox para desencriptar y descomprimir al hacer clic
            listaArchivos.SelectedIndexChanged += ListaArchivos_SelectedIndexChanged;
        }


        // Evento para manejar la selecci�n del archivo en el ListBox
        private void ListaArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            compressAndEncrypt decryptAes = new compressAndEncrypt();

            if (listaArchivos.SelectedItem != null)
            {
                string filePath = listaArchivos.SelectedItem.ToString();
                string baseFileName = Path.GetFileNameWithoutExtension(filePath).Replace("_encrypted", "");

                // Leer el archivo encriptado como bytes
                byte[] encryptedFile = File.ReadAllBytes(filePath);

                // Buscar el archivo de claves que coincide con el nombre base
                string keysFilePath = Path.Combine(@"../../../../claves/", $"{baseFileName}_keys.zip");

                if (!File.Exists(keysFilePath))
                {
                    MessageBox.Show("No se encontr� el archivo de claves correspondiente.");
                    return;
                }

                // Leer y descomprimir las claves del archivo ZIP
                Dictionary<string, byte[]> keys = decryptAes.DecompressFiles(File.ReadAllBytes(keysFilePath));

                if (keys == null || !keys.ContainsKey("Kfile") || !keys.ContainsKey("IV"))
                {
                    MessageBox.Show("Error al leer las claves comprimidas.");
                    return;
                }

                // Obtener la clave (Kfile) y el IV desde el archivo comprimido
                byte[] key = keys["Kfile"];
                byte[] iv = keys["IV"];

                // Desencriptar el archivo
                byte[] decryptedFile = decryptAes.DecryptAes(encryptedFile, key, iv);

                // Descomprimir el archivo desencriptado
                Dictionary<string, byte[]> decompressedFiles = decryptAes.DecompressFiles(decryptedFile);

                // Guardar los archivos descomprimidos
                string outputPath = @"../../../../archivos_descomprimidos/";
                if (!Directory.Exists(outputPath))
                    Directory.CreateDirectory(outputPath);

                foreach (var file in decompressedFiles)
                {
                    File.WriteAllBytes(Path.Combine(outputPath, file.Key), file.Value);
                }

                MessageBox.Show("Archivo desencriptado y descomprimido exitosamente.");
            }
        }



        private void buttonAcceder_Click(object sender, EventArgs e)
        {
            panelListado.Visible = true;
            panelAcceso.Visible = false;
            panelCifrado.Visible = false;
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
            // Crear un di�logo para seleccionar archivos
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
                    listaExaminados.Items.Add(filePath);  // Agregar la ruta del archivo al ListBox
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

        // Evento cuando el usuario hace clic en el bot�n "Confirmar"
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (listaExaminados.Items.Count > 0)
            {
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

                // Crear el diccionario que contendr� la clave (Kfile) y el IV
                Dictionary<string, byte[]> claves = new Dictionary<string, byte[]>()
        {
            { "Kfile", key },
            { "IV", iv }
        };

                // Crear un nombre �nico basado en la fecha y hora actual
                string uniqueFileName = $"output_{DateTime.Now.Ticks}";

                // Comprimir las claves
                byte[] compressedKeys = compressAndEncrypt.CompressFiles(claves);

                // Guardar el archivo comprimido (ZIP) en el sistema de archivos con el nombre �nico
                string keysFilePath = Path.Combine(@"../../../../claves/", $"{uniqueFileName}_keys.zip");
                File.WriteAllBytes(keysFilePath, compressedKeys);

                // Comprimir y cifrar los archivos seleccionados
                byte[] encryptedZip = compressAndEncrypt.CompressAndEncryptFiles(files, key, iv);

                // Guardar el archivo ZIP cifrado en una ubicaci�n deseada con el mismo nombre �nico
                string encryptedFilePath = Path.Combine(@"../../../../archivos/", $"{uniqueFileName}_encrypted.zip");
                File.WriteAllBytes(encryptedFilePath, encryptedZip);

                MessageBox.Show($"Archivos comprimidos y cifrados con �xito.\nGuardado en: {encryptedFilePath}\nClaves guardadas en: {keysFilePath}");



                // Limpiar el ListBox despu�s de confirmar
                listaArchivos.Items.Clear();
                panelListado.Visible = true;
                panelAcceso.Visible = false;
                panelCifrado.Visible = false;


                string folderPath = @"../../../../archivos/";
                string[] fnuevos = Directory.GetFiles(folderPath);
                listaArchivos.Items.AddRange(fnuevos);

            }
            else
            {
                MessageBox.Show("No se han seleccionado archivos. Por favor, selecciona los archivos antes de confirmar.");
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            listarArchivos();
            panelListado.Visible = true;
            panelAcceso.Visible = false;
            panelCifrado.Visible = false;
        }
        private void listarArchivos()
        {
            listaArchivos.Items.Clear();
            string folderPath = @"../../../../archivos/";
            string[] fnuevos = Directory.GetFiles(folderPath);
            listaArchivos.Items.AddRange(fnuevos);
        }

        private void input_nombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
