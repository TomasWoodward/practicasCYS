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
            buttonAcceder.Location = new Point(324, 345);
            buttonAcceder.Margin = new Padding(3, 4, 3, 4);
            buttonAcceder.Name = "buttonAcceder";
            buttonAcceder.Size = new Size(132, 40);
            buttonAcceder.TabIndex = 0;
            buttonAcceder.Text = "Acceder";
            buttonAcceder.UseVisualStyleBackColor = true;
            buttonAcceder.Click += buttonAcceder_Click;
            // 
            // panelAcceso
            // 
            panelAcceso.Controls.Add(labelPassword);
            panelAcceso.Controls.Add(textBoxPassword);
            panelAcceso.Controls.Add(buttonAcceder);
            panelAcceso.Location = new Point(12, 29);
            panelAcceso.Margin = new Padding(3, 4, 3, 4);
            panelAcceso.Name = "panelAcceso";
            panelAcceso.Size = new Size(776, 519);
            panelAcceso.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(321, 251);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(148, 20);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Contraseña de datos:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(219, 294);
            textBoxPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(331, 27);
            textBoxPassword.TabIndex = 1;
            // 
            // panelCifrado
            // 
            panelCifrado.Controls.Add(buttonConfirmar);
            panelCifrado.Controls.Add(buttonExaminar);
            panelCifrado.Controls.Add(listaExaminados);
            panelCifrado.Location = new Point(0, 4);
            panelCifrado.Margin = new Padding(3, 4, 3, 4);
            panelCifrado.Name = "panelCifrado";
            panelCifrado.Size = new Size(776, 515);
            panelCifrado.TabIndex = 3;
            // 
            // buttonConfirmar
            // 
            buttonConfirmar.Location = new Point(662, 449);
            buttonConfirmar.Margin = new Padding(3, 4, 3, 4);
            buttonConfirmar.Name = "buttonConfirmar";
            buttonConfirmar.Size = new Size(75, 29);
            buttonConfirmar.TabIndex = 2;
            buttonConfirmar.Text = "Confirmar";
            buttonConfirmar.UseVisualStyleBackColor = true;
            // 
            // buttonExaminar
            // 
            buttonExaminar.Location = new Point(31, 72);
            buttonExaminar.Margin = new Padding(3, 4, 3, 4);
            buttonExaminar.Name = "buttonExaminar";
            buttonExaminar.Size = new Size(75, 29);
            buttonExaminar.TabIndex = 1;
            buttonExaminar.Text = "Examinar";
            buttonExaminar.UseVisualStyleBackColor = true;
            buttonExaminar.Click += buttonExaminar_Click;
            // 
            // listaExaminados
            // 
            listaExaminados.FormattingEnabled = true;
            listaExaminados.Location = new Point(31, 130);
            listaExaminados.Margin = new Padding(3, 4, 3, 4);
            listaExaminados.Name = "listaExaminados";
            listaExaminados.Size = new Size(706, 284);
            listaExaminados.TabIndex = 0;
            // 
            // panelListado
            // 
            panelListado.Controls.Add(buttonCifrar);
            panelListado.Controls.Add(listaArchivos);
            panelListado.Location = new Point(12, 29);
            panelListado.Margin = new Padding(3, 4, 3, 4);
            panelListado.Name = "panelListado";
            panelListado.Size = new Size(776, 519);
            panelListado.TabIndex = 2;
            // 
            // buttonCifrar
            // 
            buttonCifrar.Location = new Point(638, 58);
            buttonCifrar.Margin = new Padding(3, 4, 3, 4);
            buttonCifrar.Name = "buttonCifrar";
            buttonCifrar.Size = new Size(75, 29);
            buttonCifrar.TabIndex = 1;
            buttonCifrar.Text = "Cifrar";
            buttonCifrar.UseVisualStyleBackColor = true;
            buttonCifrar.Click += buttonCifrar_Click;
            // 
            // listaArchivos
            // 
            listaArchivos.FormattingEnabled = true;
            listaArchivos.Location = new Point(49, 112);
            listaArchivos.Margin = new Padding(3, 4, 3, 4);
            listaArchivos.Name = "listaArchivos";
            listaArchivos.Size = new Size(664, 384);
            listaArchivos.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(panelAcceso);
            Controls.Add(panelListado);
            Controls.Add(panelCifrado);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            panelAcceso.ResumeLayout(false);
            panelAcceso.PerformLayout();
            panelCifrado.ResumeLayout(false);
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
    
    }
}
