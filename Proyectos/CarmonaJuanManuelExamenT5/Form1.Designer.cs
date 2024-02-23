namespace CarmonaJuanManuelExamenT5
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chicago = new System.Windows.Forms.RadioButton();
            this.lA = new System.Windows.Forms.RadioButton();
            this.ny = new System.Windows.Forms.RadioButton();
            this.granCiudad = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreCiudad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chicago);
            this.panel1.Controls.Add(this.lA);
            this.panel1.Controls.Add(this.ny);
            this.panel1.Location = new System.Drawing.Point(266, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zona horaria";
            // 
            // chicago
            // 
            this.chicago.AutoSize = true;
            this.chicago.Location = new System.Drawing.Point(4, 71);
            this.chicago.Name = "chicago";
            this.chicago.Size = new System.Drawing.Size(64, 17);
            this.chicago.TabIndex = 2;
            this.chicago.TabStop = true;
            this.chicago.Text = "Chicago";
            this.chicago.UseVisualStyleBackColor = true;
            // 
            // lA
            // 
            this.lA.AutoSize = true;
            this.lA.Location = new System.Drawing.Point(4, 47);
            this.lA.Name = "lA";
            this.lA.Size = new System.Drawing.Size(83, 17);
            this.lA.TabIndex = 1;
            this.lA.TabStop = true;
            this.lA.Text = "Los Angeles";
            this.lA.UseVisualStyleBackColor = true;
            // 
            // ny
            // 
            this.ny.AutoSize = true;
            this.ny.Location = new System.Drawing.Point(4, 23);
            this.ny.Name = "ny";
            this.ny.Size = new System.Drawing.Size(80, 17);
            this.ny.TabIndex = 0;
            this.ny.TabStop = true;
            this.ny.Text = "Nueva york";
            this.ny.UseVisualStyleBackColor = true;
            // 
            // granCiudad
            // 
            this.granCiudad.AutoSize = true;
            this.granCiudad.Location = new System.Drawing.Point(301, 150);
            this.granCiudad.Name = "granCiudad";
            this.granCiudad.Size = new System.Drawing.Size(134, 17);
            this.granCiudad.TabIndex = 1;
            this.granCiudad.Text = "Solo ciudades grandes";
            this.granCiudad.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ciudad:";
            // 
            // nombreCiudad
            // 
            this.nombreCiudad.Location = new System.Drawing.Point(301, 237);
            this.nombreCiudad.Name = "nombreCiudad";
            this.nombreCiudad.Size = new System.Drawing.Size(118, 20);
            this.nombreCiudad.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nombreCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.granCiudad);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton chicago;
        private System.Windows.Forms.RadioButton lA;
        private System.Windows.Forms.RadioButton ny;
        private System.Windows.Forms.CheckBox granCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreCiudad;
        private System.Windows.Forms.Button button1;
    }
}

