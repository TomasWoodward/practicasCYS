namespace Cys_practica1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Btn_examinar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        LBox_Archivos.Items.Add(fileName);
                    }
                }
            }
        }

        private void Button_entrar_Click(object sender, EventArgs e)
        {
            panel_Name.Visible = false;
            panel_cifrar.Visible = false;
        }

        private void Lbl_pass_Click(object sender, EventArgs e)
        {

        }
    }
}
