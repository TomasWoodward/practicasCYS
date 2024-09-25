namespace Cys_practica1
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Lbl_pass = new Label();
            textBox1 = new TextBox();
            Button_entrar = new Button();
            panel_Name = new Panel();
            panel_cifrar = new Panel();
            LBox_Archivos = new ListBox();
            Btn_examinar = new Button();
            Btn_cifrar = new Button();
            panel_Listado = new Panel();
            panel_Name.SuspendLayout();
            panel_cifrar.SuspendLayout();
            SuspendLayout();
            // 
            // Lbl_pass
            // 
            Lbl_pass.AutoSize = true;
            Lbl_pass.Location = new Point(48, 63);
            Lbl_pass.Name = "Lbl_pass";
            Lbl_pass.Size = new Size(147, 20);
            Lbl_pass.TabIndex = 2;
            Lbl_pass.Text = "Contraseña de Datos";
            Lbl_pass.Click += Lbl_pass_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(21, 98);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 27);
            textBox1.TabIndex = 3;
            // 
            // Button_entrar
            // 
            Button_entrar.Location = new Point(78, 143);
            Button_entrar.Name = "Button_entrar";
            Button_entrar.Size = new Size(94, 29);
            Button_entrar.TabIndex = 4;
            Button_entrar.Text = "Acceder";
            Button_entrar.UseVisualStyleBackColor = true;
            Button_entrar.Click += Button_entrar_Click;
            // 
            // panel_Name
            // 
            panel_Name.Controls.Add(Button_entrar);
            panel_Name.Controls.Add(textBox1);
            panel_Name.Controls.Add(Lbl_pass);
            panel_Name.Location = new Point(205, 68);
            panel_Name.Name = "panel_Name";
            panel_Name.Size = new Size(250, 222);
            panel_Name.TabIndex = 5;
            // 
            // panel_cifrar
            // 
            panel_cifrar.Controls.Add(panel_Listado);
            panel_cifrar.Controls.Add(LBox_Archivos);
            panel_cifrar.Controls.Add(Btn_examinar);
            panel_cifrar.Controls.Add(Btn_cifrar);
            panel_cifrar.Location = new Point(12, 12);
            panel_cifrar.Name = "panel_cifrar";
            panel_cifrar.Size = new Size(640, 372);
            panel_cifrar.TabIndex = 6;
            // 
            // LBox_Archivos
            // 
            LBox_Archivos.FormattingEnabled = true;
            LBox_Archivos.Location = new Point(36, 70);
            LBox_Archivos.Name = "LBox_Archivos";
            LBox_Archivos.Size = new Size(509, 204);
            LBox_Archivos.TabIndex = 2;
            // 
            // Btn_examinar
            // 
            Btn_examinar.Location = new Point(36, 26);
            Btn_examinar.Name = "Btn_examinar";
            Btn_examinar.Size = new Size(94, 29);
            Btn_examinar.TabIndex = 1;
            Btn_examinar.Text = "Examinar";
            Btn_examinar.UseVisualStyleBackColor = true;
            Btn_examinar.Click += Btn_examinar_Click;
            // 
            // Btn_cifrar
            // 
            Btn_cifrar.Location = new Point(506, 313);
            Btn_cifrar.Name = "Btn_cifrar";
            Btn_cifrar.Size = new Size(110, 38);
            Btn_cifrar.TabIndex = 0;
            Btn_cifrar.Text = "Cifrar";
            Btn_cifrar.UseVisualStyleBackColor = true;
            // 
            // panel_Listado
            // 
            panel_Listado.Location = new Point(0, 0);
            panel_Listado.Name = "panel_Listado";
            panel_Listado.Size = new Size(640, 372);
            panel_Listado.TabIndex = 3;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 396);
            Controls.Add(panel_cifrar);
            Controls.Add(panel_Name);
            Name = "Inicio";
            Text = "Form1";
            panel_Name.ResumeLayout(false);
            panel_Name.PerformLayout();
            panel_cifrar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label Lbl_pass;
        private TextBox textBox1;
        private Button Button_entrar;
        private Panel panel_Name;
        private Panel panel_cifrar;
        private Button Btn_cifrar;
        private ListBox LBox_Archivos;
        private Button Btn_examinar;
        private Panel panel_Listado;
    }
}
