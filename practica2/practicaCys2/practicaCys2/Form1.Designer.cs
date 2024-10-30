namespace practicaCys2
{
    partial class Form1
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

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonAcceder = new Button();
            panelAcceso = new Panel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            panelClaro = new Panel();
            textBoxUser = new TextBox();
            label6 = new Label();
            textBoxPassword = new TextBox();
            pictureBox1 = new PictureBox();
            labelPassword = new Label();
            panelCifrado = new Panel();
            textBoxNombreArchivo = new TextBox();
            panel3 = new Panel();
            label10 = new Label();
            label5 = new Label();
            pictureBox4 = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            button_back = new Button();
            buttonConfirmar = new Button();
            buttonExaminar = new Button();
            listaExaminados = new ListBox();
            panelListado = new Panel();
            panel2 = new Panel();
            label7 = new Label();
            pictureBox3 = new PictureBox();
            label4 = new Label();
            label1 = new Label();
            buttonCifrar = new Button();
            listaArchivos = new ListBox();
            panelAcceso.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelClaro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelCifrado.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelListado.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // buttonAcceder
            // 
            buttonAcceder.Anchor = AnchorStyles.None;
            buttonAcceder.BackColor = SystemColors.ControlLight;
            buttonAcceder.Cursor = Cursors.Hand;
            buttonAcceder.FlatAppearance.BorderColor = Color.Gray;
            buttonAcceder.FlatAppearance.MouseDownBackColor = SystemColors.ButtonHighlight;
            buttonAcceder.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonAcceder.FlatStyle = FlatStyle.Flat;
            buttonAcceder.Location = new Point(258, 362);
            buttonAcceder.Margin = new Padding(0);
            buttonAcceder.Name = "buttonAcceder";
            buttonAcceder.Size = new Size(140, 40);
            buttonAcceder.TabIndex = 0;
            buttonAcceder.Text = "Acceder";
            buttonAcceder.UseVisualStyleBackColor = false;
            buttonAcceder.Click += buttonAcceder_Click;
            // 
            // panelAcceso
            // 
            panelAcceso.AutoSize = true;
            panelAcceso.BackColor = Color.FromArgb(5, 57, 91);
            panelAcceso.Controls.Add(panel1);
            panelAcceso.Controls.Add(panelClaro);
            panelAcceso.Dock = DockStyle.Fill;
            panelAcceso.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelAcceso.Location = new Point(0, 0);
            panelAcceso.Margin = new Padding(3, 4, 3, 4);
            panelAcceso.Name = "panelAcceso";
            panelAcceso.Size = new Size(932, 553);
            panelAcceso.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 40, 63);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(932, 64);
            panel1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(811, 20);
            label2.Name = "label2";
            label2.Size = new Size(99, 26);
            label2.TabIndex = 5;
            label2.Text = "FileLockr";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.ImageAlign = ContentAlignment.TopLeft;
            label3.Location = new Point(64, 20);
            label3.Name = "label3";
            label3.Size = new Size(76, 22);
            label3.TabIndex = 0;
            label3.Text = "ACCESO";
            // 
            // panelClaro
            // 
            panelClaro.Anchor = AnchorStyles.None;
            panelClaro.BackColor = Color.FromArgb(8, 79, 122);
            panelClaro.Controls.Add(textBoxUser);
            panelClaro.Controls.Add(label6);
            panelClaro.Controls.Add(textBoxPassword);
            panelClaro.Controls.Add(pictureBox1);
            panelClaro.Controls.Add(buttonAcceder);
            panelClaro.Controls.Add(labelPassword);
            panelClaro.Location = new Point(138, 82);
            panelClaro.Name = "panelClaro";
            panelClaro.Padding = new Padding(0, 15, 0, 0);
            panelClaro.Size = new Size(656, 448);
            panelClaro.TabIndex = 6;
            // 
            // textBoxUser
            // 
            textBoxUser.Anchor = AnchorStyles.None;
            textBoxUser.BackColor = SystemColors.ControlLight;
            textBoxUser.Location = new Point(178, 210);
            textBoxUser.Margin = new Padding(0);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(300, 28);
            textBoxUser.TabIndex = 5;
            textBoxUser.TextAlign = HorizontalAlignment.Center;
            textBoxUser.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.BackColor = Color.FromArgb(8, 79, 122);
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(178, 170);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(300, 30);
            label6.TabIndex = 6;
            label6.Text = "Introduzca el nombre de usuario";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.BackColor = SystemColors.ControlLight;
            textBoxPassword.Location = new Point(178, 302);
            textBoxPassword.Margin = new Padding(0);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(300, 28);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(8, 79, 122);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 15);
            pictureBox1.Margin = new Padding(0, 10, 0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(656, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.None;
            labelPassword.BackColor = Color.FromArgb(8, 79, 122);
            labelPassword.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(171, 260);
            labelPassword.Margin = new Padding(0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(315, 30);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Introduzca la contraseña de datos";
            labelPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCifrado
            // 
            panelCifrado.BackColor = Color.FromArgb(5, 57, 91);
            panelCifrado.Controls.Add(textBoxNombreArchivo);
            panelCifrado.Controls.Add(panel3);
            panelCifrado.Controls.Add(button_back);
            panelCifrado.Controls.Add(buttonConfirmar);
            panelCifrado.Controls.Add(buttonExaminar);
            panelCifrado.Controls.Add(listaExaminados);
            panelCifrado.Dock = DockStyle.Fill;
            panelCifrado.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelCifrado.Location = new Point(0, 0);
            panelCifrado.Margin = new Padding(3, 4, 3, 4);
            panelCifrado.Name = "panelCifrado";
            panelCifrado.Size = new Size(932, 553);
            panelCifrado.TabIndex = 3;
            // 
            // textBoxNombreArchivo
            // 
            textBoxNombreArchivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxNombreArchivo.Location = new Point(560, 147);
            textBoxNombreArchivo.Name = "textBoxNombreArchivo";
            textBoxNombreArchivo.PlaceholderText = "Introduce un nombre de archivo";
            textBoxNombreArchivo.Size = new Size(316, 26);
            textBoxNombreArchivo.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(5, 40, 63);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label9);
            panel3.Dock = DockStyle.Top;
            panel3.ForeColor = SystemColors.ActiveCaptionText;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(932, 64);
            panel3.TabIndex = 5;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(811, 20);
            label10.Name = "label10";
            label10.Size = new Size(99, 26);
            label10.TabIndex = 9;
            label10.Text = "FileLockr";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(1531, 20);
            label5.Name = "label5";
            label5.Size = new Size(99, 26);
            label5.TabIndex = 8;
            label5.Text = "FileLockr";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(12, 15);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(48, 34);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(2275, 20);
            label8.Name = "label8";
            label8.Size = new Size(99, 26);
            label8.TabIndex = 5;
            label8.Text = "FileLockr";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.ImageAlign = ContentAlignment.TopLeft;
            label9.Location = new Point(64, 20);
            label9.Name = "label9";
            label9.Size = new Size(104, 22);
            label9.TabIndex = 0;
            label9.Text = "ENCRIPTAR";
            // 
            // button_back
            // 
            button_back.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_back.Cursor = Cursors.Hand;
            button_back.FlatAppearance.BorderColor = Color.White;
            button_back.FlatAppearance.BorderSize = 2;
            button_back.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 255, 128);
            button_back.Font = new Font("Wingdings 3", 9F, FontStyle.Regular, GraphicsUnit.Point, 2);
            button_back.Image = (Image)resources.GetObject("button_back.Image");
            button_back.Location = new Point(52, 439);
            button_back.Name = "button_back";
            button_back.Size = new Size(42, 42);
            button_back.TabIndex = 4;
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // buttonConfirmar
            // 
            buttonConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonConfirmar.BackColor = SystemColors.ButtonHighlight;
            buttonConfirmar.FlatAppearance.BorderColor = Color.Gray;
            buttonConfirmar.FlatAppearance.MouseDownBackColor = SystemColors.ButtonHighlight;
            buttonConfirmar.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonConfirmar.FlatStyle = FlatStyle.Flat;
            buttonConfirmar.Location = new Point(773, 439);
            buttonConfirmar.Margin = new Padding(3, 4, 3, 4);
            buttonConfirmar.Name = "buttonConfirmar";
            buttonConfirmar.Size = new Size(103, 38);
            buttonConfirmar.TabIndex = 2;
            buttonConfirmar.Text = "Confirmar";
            buttonConfirmar.UseVisualStyleBackColor = false;
            buttonConfirmar.Click += buttonConfirmar_Click;
            // 
            // buttonExaminar
            // 
            buttonExaminar.BackColor = SystemColors.ButtonHighlight;
            buttonExaminar.FlatAppearance.BorderColor = Color.Gray;
            buttonExaminar.FlatAppearance.MouseDownBackColor = SystemColors.ButtonHighlight;
            buttonExaminar.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonExaminar.FlatStyle = FlatStyle.Flat;
            buttonExaminar.Location = new Point(52, 140);
            buttonExaminar.Margin = new Padding(3, 4, 3, 4);
            buttonExaminar.Name = "buttonExaminar";
            buttonExaminar.Size = new Size(99, 38);
            buttonExaminar.TabIndex = 1;
            buttonExaminar.Text = "Examinar";
            buttonExaminar.UseVisualStyleBackColor = false;
            buttonExaminar.Click += buttonExaminar_Click;
            // 
            // listaExaminados
            // 
            listaExaminados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listaExaminados.BackColor = Color.FromArgb(8, 79, 122);
            listaExaminados.BorderStyle = BorderStyle.None;
            listaExaminados.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listaExaminados.ForeColor = SystemColors.Window;
            listaExaminados.FormattingEnabled = true;
            listaExaminados.ItemHeight = 22;
            listaExaminados.Location = new Point(52, 195);
            listaExaminados.Margin = new Padding(10);
            listaExaminados.Name = "listaExaminados";
            listaExaminados.ScrollAlwaysVisible = true;
            listaExaminados.Size = new Size(824, 220);
            listaExaminados.TabIndex = 0;
            // 
            // panelListado
            // 
            panelListado.BackColor = Color.FromArgb(5, 57, 91);
            panelListado.Controls.Add(panel2);
            panelListado.Controls.Add(buttonCifrar);
            panelListado.Controls.Add(listaArchivos);
            panelListado.Dock = DockStyle.Fill;
            panelListado.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelListado.Location = new Point(0, 0);
            panelListado.Margin = new Padding(3, 4, 3, 4);
            panelListado.Name = "panelListado";
            panelListado.Size = new Size(932, 553);
            panelListado.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(5, 40, 63);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.ForeColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(932, 64);
            panel2.TabIndex = 4;
            panel2.Paint += panel2_Paint;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(811, 20);
            label7.Name = "label7";
            label7.Size = new Size(99, 26);
            label7.TabIndex = 8;
            label7.Text = "FileLockr";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(12, 15);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(48, 34);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(1543, 20);
            label4.Name = "label4";
            label4.Size = new Size(99, 26);
            label4.TabIndex = 5;
            label4.Text = "FileLockr";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(64, 20);
            label1.Name = "label1";
            label1.Size = new Size(67, 22);
            label1.TabIndex = 0;
            label1.Text = "INICIO";
            // 
            // buttonCifrar
            // 
            buttonCifrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCifrar.BackColor = SystemColors.ButtonHighlight;
            buttonCifrar.FlatAppearance.BorderColor = Color.Gray;
            buttonCifrar.FlatAppearance.MouseDownBackColor = SystemColors.ButtonHighlight;
            buttonCifrar.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonCifrar.FlatStyle = FlatStyle.Flat;
            buttonCifrar.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCifrar.Location = new Point(798, 88);
            buttonCifrar.Margin = new Padding(3, 4, 3, 4);
            buttonCifrar.Name = "buttonCifrar";
            buttonCifrar.Size = new Size(100, 40);
            buttonCifrar.TabIndex = 1;
            buttonCifrar.Text = "Cifrar";
            buttonCifrar.UseVisualStyleBackColor = false;
            buttonCifrar.Click += buttonCifrar_Click;
            // 
            // listaArchivos
            // 
            listaArchivos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listaArchivos.BackColor = Color.FromArgb(8, 79, 122);
            listaArchivos.BorderStyle = BorderStyle.None;
            listaArchivos.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listaArchivos.ForeColor = SystemColors.Window;
            listaArchivos.FormattingEnabled = true;
            listaArchivos.ItemHeight = 22;
            listaArchivos.Location = new Point(36, 155);
            listaArchivos.Margin = new Padding(0);
            listaArchivos.Name = "listaArchivos";
            listaArchivos.Size = new Size(862, 352);
            listaArchivos.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(932, 553);
            Controls.Add(panelAcceso);
            Controls.Add(panelListado);
            Controls.Add(panelCifrado);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(950, 600);
            Name = "Form1";
            Text = "Form1";
            panelAcceso.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelClaro.ResumeLayout(false);
            panelClaro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelCifrado.ResumeLayout(false);
            panelCifrado.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelListado.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button buttonAcceder;
        private System.Windows.Forms.Panel panelAcceso;
        private System.Windows.Forms.Panel panelListado;
        private System.Windows.Forms.ListBox listaArchivos;
        private System.Windows.Forms.Button buttonCifrar;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Panel panelCifrado;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Button buttonExaminar;
        private System.Windows.Forms.ListBox listaExaminados;
        private Button button_back;
  
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Panel panelClaro;
        private TextBox textBoxUser;
        private Label label6;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label label7;
        private PictureBox pictureBox3;
        private Label label4;
        private Label label1;
        private Panel panel3;
        private Label label5;
        private PictureBox pictureBox4;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBoxNombreArchivo;
    }
}
