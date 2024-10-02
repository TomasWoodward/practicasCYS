using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            // Crear un nuevo cuadro de diálogo de "Abrir archivo"
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Opcional: Configurar propiedades del cuadro de diálogo
            openFileDialog.InitialDirectory = "C:\\"; // Carpeta inicial
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"; // Tipos de archivos que se pueden abrir
            openFileDialog.FilterIndex = 1; // Índice del filtro predeterminado
            openFileDialog.RestoreDirectory = true; // Restaurar el directorio después de seleccionar un archivo


            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = openFileDialog.FileName;
            //    MessageBox.Show("Archivo seleccionado: " + filePath);
            //}
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
