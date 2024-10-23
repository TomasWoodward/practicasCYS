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
            textBoxPassword = new TextBox();
            labelPassword = new Label();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            panelClaro = new Panel();
            pictureBox1 = new PictureBox();
            panelCifrado = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            button_back = new Button();
            input_nombre = new TextBox();
            buttonConfirmar = new Button();
            buttonExaminar = new Button();
            listaExaminados = new ListBox();
            panelListado = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            buttonCifrar = new Button();
            listaArchivos = new ListBox();
            panelAcceso.SuspendLayout();
            panel1.SuspendLayout();
            panelClaro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelCifrado.SuspendLayout();
            panel3.SuspendLayout();
            panelListado.SuspendLayout();
            panel2.SuspendLayout();
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
            buttonAcceder.Location = new Point(396, 410);
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
            panelAcceso.Controls.Add(textBoxPassword);
            panelAcceso.Controls.Add(labelPassword);
            panelAcceso.Controls.Add(buttonAcceder);
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
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.BackColor = SystemColors.ControlLight;
            textBoxPassword.Location = new Point(316, 350);
            textBoxPassword.Margin = new Padding(0);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(300, 28);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.None;
            labelPassword.BackColor = Color.FromArgb(8, 79, 122);
            labelPassword.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(308, 290);
            labelPassword.Margin = new Padding(0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(317, 30);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Introduzca la contraseña de datos";
            labelPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 40, 63);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(932, 64);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(798, 21);
            label2.Name = "label2";
            label2.Size = new Size(108, 28);
            label2.TabIndex = 5;
            label2.Text = "Encripta2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(67, 24);
            label3.Name = "label3";
            label3.Size = new Size(76, 22);
            label3.TabIndex = 0;
            label3.Text = "ACCESO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS Outlook", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 2);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(28, 24);
            label1.Name = "label1";
            label1.Size = new Size(33, 24);
            label1.TabIndex = 0;
            label1.Text = "B";
            // 
            // panelClaro
            // 
            panelClaro.Anchor = AnchorStyles.None;
            panelClaro.BackColor = Color.FromArgb(8, 79, 122);
            panelClaro.Controls.Add(pictureBox1);
            panelClaro.Location = new Point(221, 112);
            panelClaro.Name = "panelClaro";
            panelClaro.Padding = new Padding(0, 15, 0, 0);
            panelClaro.Size = new Size(490, 393);
            panelClaro.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(8, 79, 122);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 15);
            pictureBox1.Margin = new Padding(0, 10, 0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(490, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // panelCifrado
            // 
            panelCifrado.BackColor = Color.FromArgb(5, 57, 91);
            panelCifrado.Controls.Add(panel3);
            panelCifrado.Controls.Add(button_back);
            panelCifrado.Controls.Add(input_nombre);
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(5, 40, 63);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(932, 64);
            panel3.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(64, 20);
            label5.Name = "label5";
            label5.Size = new Size(160, 24);
            label5.TabIndex = 0;
            label5.Text = "NUEVO CIFRADO";
            // 
            // button_back
            // 
            button_back.Cursor = Cursors.Hand;
            button_back.FlatAppearance.BorderColor = Color.White;
            button_back.FlatAppearance.BorderSize = 2;
            button_back.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 255, 128);
            button_back.Font = new Font("Wingdings 3", 9F, FontStyle.Regular, GraphicsUnit.Point, 2);
            button_back.Location = new Point(28, 67);
            button_back.Name = "button_back";
            button_back.Size = new Size(42, 38);
            button_back.TabIndex = 4;
            button_back.Text = "Z";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // input_nombre
            // 
            input_nombre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            input_nombre.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            input_nombre.Location = new Point(500, 149);
            input_nombre.Name = "input_nombre";
            input_nombre.PlaceholderText = "Introduce un nombre para el archivo";
            input_nombre.Size = new Size(376, 28);
            input_nombre.TabIndex = 3;
            input_nombre.TextChanged += input_nombre_TextChanged;
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
            buttonConfirmar.Size = new Size(103, 34);
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
            buttonExaminar.Location = new Point(52, 143);
            buttonExaminar.Margin = new Padding(3, 4, 3, 4);
            buttonExaminar.Name = "buttonExaminar";
            buttonExaminar.Size = new Size(99, 32);
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
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(932, 64);
            panel2.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(76, 21);
            label4.Name = "label4";
            label4.Size = new Size(70, 24);
            label4.TabIndex = 0;
            label4.Text = "INICIO";
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
            panelAcceso.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelClaro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelCifrado.ResumeLayout(false);
            panelCifrado.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelListado.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private TextBox input_nombre;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Panel panelClaro;
        private Panel panel2;
        private Label label4;
        private Panel panel3;
        private Label label5;
    }
}
