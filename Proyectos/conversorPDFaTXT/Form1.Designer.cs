namespace conversorPDFaTXT
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
            this.ruta = new System.Windows.Forms.TextBox();
            this.abrirPdf = new System.Windows.Forms.Button();
            this.convertir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.persistir = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textoPlano = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ruta
            // 
            this.ruta.Location = new System.Drawing.Point(12, 410);
            this.ruta.Name = "ruta";
            this.ruta.ReadOnly = true;
            this.ruta.Size = new System.Drawing.Size(690, 20);
            this.ruta.TabIndex = 1;
            // 
            // abrirPdf
            // 
            this.abrirPdf.Location = new System.Drawing.Point(768, 381);
            this.abrirPdf.Name = "abrirPdf";
            this.abrirPdf.Size = new System.Drawing.Size(113, 23);
            this.abrirPdf.TabIndex = 2;
            this.abrirPdf.Text = "Abrir pdf";
            this.abrirPdf.UseVisualStyleBackColor = true;
            this.abrirPdf.Click += new System.EventHandler(this.abrirPdf_Click);
            // 
            // convertir
            // 
            this.convertir.Location = new System.Drawing.Point(768, 410);
            this.convertir.Name = "convertir";
            this.convertir.Size = new System.Drawing.Size(113, 23);
            this.convertir.TabIndex = 3;
            this.convertir.Text = "Convertir";
            this.convertir.UseVisualStyleBackColor = true;
            this.convertir.Click += new System.EventHandler(this.convertir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // persistir
            // 
            this.persistir.Location = new System.Drawing.Point(768, 439);
            this.persistir.Name = "persistir";
            this.persistir.Size = new System.Drawing.Size(113, 23);
            this.persistir.TabIndex = 4;
            this.persistir.Text = "Guardar texto";
            this.persistir.UseVisualStyleBackColor = true;
            this.persistir.Click += new System.EventHandler(this.persistir_Click);
            // 
            // textoPlano
            // 
            this.textoPlano.Location = new System.Drawing.Point(12, 12);
            this.textoPlano.Name = "textoPlano";
            this.textoPlano.Size = new System.Drawing.Size(869, 354);
            this.textoPlano.TabIndex = 5;
            this.textoPlano.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 472);
            this.Controls.Add(this.textoPlano);
            this.Controls.Add(this.persistir);
            this.Controls.Add(this.convertir);
            this.Controls.Add(this.abrirPdf);
            this.Controls.Add(this.ruta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ruta;
        private System.Windows.Forms.Button abrirPdf;
        private System.Windows.Forms.Button convertir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button persistir;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RichTextBox textoPlano;
    }
}

