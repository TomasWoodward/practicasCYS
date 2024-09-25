namespace practicaCys
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAcceder = new System.Windows.Forms.Button();
            this.panelAcceso = new System.Windows.Forms.Panel();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.panelCifrado = new System.Windows.Forms.Panel();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.buttonExaminar = new System.Windows.Forms.Button();
            this.listaExaminados = new System.Windows.Forms.ListBox();
            this.panelListado = new System.Windows.Forms.Panel();
            this.buttonCifrar = new System.Windows.Forms.Button();
            this.listaArchivos = new System.Windows.Forms.ListBox();
            this.panelAcceso.SuspendLayout();
            this.panelCifrado.SuspendLayout();
            this.panelListado.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAcceder
            // 
            this.buttonAcceder.Location = new System.Drawing.Point(324, 276);
            this.buttonAcceder.Name = "buttonAcceder";
            this.buttonAcceder.Size = new System.Drawing.Size(132, 32);
            this.buttonAcceder.TabIndex = 0;
            this.buttonAcceder.Text = "Acceder";
            this.buttonAcceder.UseVisualStyleBackColor = true;
            this.buttonAcceder.Click += new System.EventHandler(this.buttonAcceder_Click);
            // 
            // panelAcceso
            // 
            this.panelAcceso.Controls.Add(this.labelPassword);
            this.panelAcceso.Controls.Add(this.textBoxPassword);
            this.panelAcceso.Controls.Add(this.buttonAcceder);
            this.panelAcceso.Controls.Add(this.panelCifrado);
            this.panelAcceso.Location = new System.Drawing.Point(12, 23);
            this.panelAcceso.Name = "panelAcceso";
            this.panelAcceso.Size = new System.Drawing.Size(776, 415);
            this.panelAcceso.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(321, 201);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(135, 16);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Contraseña de datos:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(219, 235);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(331, 22);
            this.textBoxPassword.TabIndex = 1;
            // 
            // panelCifrado
            // 
            this.panelCifrado.Controls.Add(this.buttonConfirmar);
            this.panelCifrado.Controls.Add(this.buttonExaminar);
            this.panelCifrado.Controls.Add(this.listaExaminados);
            this.panelCifrado.Location = new System.Drawing.Point(0, 3);
            this.panelCifrado.Name = "panelCifrado";
            this.panelCifrado.Size = new System.Drawing.Size(776, 412);
            this.panelCifrado.TabIndex = 3;
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(662, 359);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmar.TabIndex = 2;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            // 
            // buttonExaminar
            // 
            this.buttonExaminar.Location = new System.Drawing.Point(31, 58);
            this.buttonExaminar.Name = "buttonExaminar";
            this.buttonExaminar.Size = new System.Drawing.Size(75, 23);
            this.buttonExaminar.TabIndex = 1;
            this.buttonExaminar.Text = "Examinar";
            this.buttonExaminar.UseVisualStyleBackColor = true;
            // 
            // listaExaminados
            // 
            this.listaExaminados.FormattingEnabled = true;
            this.listaExaminados.ItemHeight = 16;
            this.listaExaminados.Location = new System.Drawing.Point(31, 104);
            this.listaExaminados.Name = "listaExaminados";
            this.listaExaminados.Size = new System.Drawing.Size(706, 228);
            this.listaExaminados.TabIndex = 0;
            // 
            // panelListado
            // 
            this.panelListado.Controls.Add(this.buttonCifrar);
            this.panelListado.Controls.Add(this.listaArchivos);
            this.panelListado.Location = new System.Drawing.Point(12, 23);
            this.panelListado.Name = "panelListado";
            this.panelListado.Size = new System.Drawing.Size(776, 415);
            this.panelListado.TabIndex = 2;
            // 
            // buttonCifrar
            // 
            this.buttonCifrar.Location = new System.Drawing.Point(638, 46);
            this.buttonCifrar.Name = "buttonCifrar";
            this.buttonCifrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCifrar.TabIndex = 1;
            this.buttonCifrar.Text = "Cifrar";
            this.buttonCifrar.UseVisualStyleBackColor = true;
            this.buttonCifrar.Click += new System.EventHandler(this.buttonCifrar_Click);
            // 
            // listaArchivos
            // 
            this.listaArchivos.FormattingEnabled = true;
            this.listaArchivos.ItemHeight = 16;
            this.listaArchivos.Location = new System.Drawing.Point(49, 90);
            this.listaArchivos.Name = "listaArchivos";
            this.listaArchivos.Size = new System.Drawing.Size(664, 308);
            this.listaArchivos.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelAcceso);
            this.Controls.Add(this.panelListado);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelAcceso.ResumeLayout(false);
            this.panelAcceso.PerformLayout();
            this.panelCifrado.ResumeLayout(false);
            this.panelListado.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

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

