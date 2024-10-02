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

        // Evento cuando el usuario hace clic en el botón "Confirmar"
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (listaExaminados.Items.Count > 0)
            {
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
                byte[] key = new byte[32];
                RandomNumberGenerator.Fill(key); // Generar 32 bytes aleatorios para la clave

                byte[] iv = new byte[16];
                RandomNumberGenerator.Fill(iv); // Generar 16 bytes aleatorios para el IV

                // Comprimir y cifrar los archivos seleccionados
                compressAndEncrypt compressAndEncrypt = new compressAndEncrypt();
                byte[] encryptedZip = compressAndEncrypt.CompressAndEncryptFiles(files, key, iv);

                // Guardar el archivo ZIP cifrado en una ubicación deseada
                string encryptedFilePath = @"../../../../archivos/output_encrypted.zip";
                File.WriteAllBytes(encryptedFilePath, encryptedZip);

                MessageBox.Show($"Archivos comprimidos y cifrados con éxito.\nGuardado en: {encryptedFilePath}");

                // Limpiar el ListBox después de confirmar
                listaArchivos.Items.Clear();
            }
            else
            {
                MessageBox.Show("No se han seleccionado archivos. Por favor, selecciona los archivos antes de confirmar.");
            }
        }

    }
}
