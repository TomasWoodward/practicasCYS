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
            buttonAcceder = new Button();
            panelAcceso = new Panel();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            panelCifrado = new Panel();
            button_back = new Button();
            input_nombre = new TextBox();
            buttonConfirmar = new Button();
            buttonExaminar = new Button();
            listaExaminados = new ListBox();
            panelListado = new Panel();
            buttonCifrar = new Button();
            listaArchivos = new ListBox();
            panelAcceso.SuspendLayout();
            panelCifrado.SuspendLayout();
            panelListado.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAcceder
            // 
            buttonAcceder.Location = new Point(337, 254);
            buttonAcceder.Margin = new Padding(3, 4, 3, 4);
            buttonAcceder.Name = "buttonAcceder";
            buttonAcceder.Size = new Size(123, 35);
            buttonAcceder.TabIndex = 0;
            buttonAcceder.Text = "Acceder";
            buttonAcceder.UseVisualStyleBackColor = true;
            buttonAcceder.Click += buttonAcceder_Click;
            // 
            // panelAcceso
            // 
            panelAcceso.BackColor = SystemColors.GradientInactiveCaption;
            panelAcceso.Controls.Add(labelPassword);
            panelAcceso.Controls.Add(textBoxPassword);
            panelAcceso.Controls.Add(buttonAcceder);
            panelAcceso.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelAcceso.Location = new Point(12, 29);
            panelAcceso.Margin = new Padding(3, 4, 3, 4);
            panelAcceso.Name = "panelAcceso";
            panelAcceso.Size = new Size(776, 519);
            panelAcceso.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.Location = new Point(295, 149);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(194, 24);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Contraseña de datos";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(267, 202);
            textBoxPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(240, 28);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            // 
            // panelCifrado
            // 
            panelCifrado.Controls.Add(button_back);
            panelCifrado.Controls.Add(input_nombre);
            panelCifrado.Controls.Add(buttonConfirmar);
            panelCifrado.Controls.Add(buttonExaminar);
            panelCifrado.Controls.Add(listaExaminados);
            panelCifrado.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelCifrado.Location = new Point(0, 4);
            panelCifrado.Margin = new Padding(3, 4, 3, 4);
            panelCifrado.Name = "panelCifrado";
            panelCifrado.Size = new Size(776, 515);
            panelCifrado.TabIndex = 3;
            // 
            // button_back
            // 
            button_back.Location = new Point(28, 26);
            button_back.Name = "button_back";
            button_back.Size = new Size(42, 38);
            button_back.TabIndex = 4;
            button_back.Text = "<";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // input_nombre
            // 
            input_nombre.Location = new Point(349, 111);
            input_nombre.Name = "input_nombre";
            input_nombre.PlaceholderText = "Introduce un nombre para el archivo";
            input_nombre.Size = new Size(376, 26);
            input_nombre.TabIndex = 3;
            // 
            // buttonConfirmar
            // 
            buttonConfirmar.Location = new Point(622, 466);
            buttonConfirmar.Margin = new Padding(3, 4, 3, 4);
            buttonConfirmar.Name = "buttonConfirmar";
            buttonConfirmar.Size = new Size(103, 45);
            buttonConfirmar.TabIndex = 2;
            buttonConfirmar.Text = "Confirmar";
            buttonConfirmar.UseVisualStyleBackColor = true;
            buttonConfirmar.Click += buttonConfirmar_Click;
            // 
            // buttonExaminar
            // 
            buttonExaminar.Location = new Point(52, 98);
            buttonExaminar.Margin = new Padding(3, 4, 3, 4);
            buttonExaminar.Name = "buttonExaminar";
            buttonExaminar.Size = new Size(99, 40);
            buttonExaminar.TabIndex = 1;
            buttonExaminar.Text = "Examinar";
            buttonExaminar.UseVisualStyleBackColor = true;
            buttonExaminar.Click += buttonExaminar_Click;
            // 
            // listaExaminados
            // 
            listaExaminados.FormattingEnabled = true;
            listaExaminados.ItemHeight = 18;
            listaExaminados.Location = new Point(52, 156);
            listaExaminados.Margin = new Padding(3, 4, 3, 4);
            listaExaminados.Name = "listaExaminados";
            listaExaminados.Size = new Size(673, 274);
            listaExaminados.TabIndex = 0;
            // 
            // panelListado
            // 
            panelListado.Controls.Add(buttonCifrar);
            panelListado.Controls.Add(listaArchivos);
            panelListado.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelListado.Location = new Point(12, 29);
            panelListado.Margin = new Padding(3, 4, 3, 4);
            panelListado.Name = "panelListado";
            panelListado.Size = new Size(776, 519);
            panelListado.TabIndex = 2;
            // 
            // buttonCifrar
            // 
            buttonCifrar.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCifrar.Location = new Point(610, 58);
            buttonCifrar.Margin = new Padding(3, 4, 3, 4);
            buttonCifrar.Name = "buttonCifrar";
            buttonCifrar.Size = new Size(103, 37);
            buttonCifrar.TabIndex = 1;
            buttonCifrar.Text = "Cifrar";
            buttonCifrar.UseVisualStyleBackColor = true;
            buttonCifrar.Click += buttonCifrar_Click;
            // 
            // listaArchivos
            // 
            listaArchivos.FormattingEnabled = true;
            listaArchivos.ItemHeight = 18;
            listaArchivos.Location = new Point(56, 112);
            listaArchivos.Margin = new Padding(3, 4, 3, 4);
            listaArchivos.Name = "listaArchivos";
            listaArchivos.Size = new Size(657, 346);
            listaArchivos.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(panelListado);
            Controls.Add(panelCifrado);
            Controls.Add(panelAcceso);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            panelAcceso.ResumeLayout(false);
            panelAcceso.PerformLayout();
            panelCifrado.ResumeLayout(false);
            panelCifrado.PerformLayout();
            panelListado.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}
