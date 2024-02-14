namespace InformeConPostgres1
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mas500ToolStrip = new System.Windows.Forms.ToolStrip();
            this.mas500ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.vuelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tuViajeFinDeCursoDataSet = new InformeConPostgres1.TuViajeFinDeCursoDataSet();
            this.vuelosTableAdapter = new InformeConPostgres1.TuViajeFinDeCursoDataSetTableAdapters.vuelosTableAdapter();
            this.mas800ToolStrip = new System.Windows.Forms.ToolStrip();
            this.mas800ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mas500ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vuelosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuViajeFinDeCursoDataSet)).BeginInit();
            this.mas800ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "VuelosTVFDC";
            reportDataSource1.Value = this.vuelosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InformeConPostgres1.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // mas500ToolStrip
            // 
            this.mas500ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mas500ToolStripButton});
            this.mas500ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mas500ToolStrip.Name = "mas500ToolStrip";
            this.mas500ToolStrip.Size = new System.Drawing.Size(800, 25);
            this.mas500ToolStrip.TabIndex = 1;
            this.mas500ToolStrip.Text = "mas500ToolStrip";
            // 
            // mas500ToolStripButton
            // 
            this.mas500ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mas500ToolStripButton.Name = "mas500ToolStripButton";
            this.mas500ToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.mas500ToolStripButton.Text = "mas500";
            this.mas500ToolStripButton.Click += new System.EventHandler(this.mas500ToolStripButton_Click);
            // 
            // vuelosBindingSource
            // 
            this.vuelosBindingSource.DataMember = "vuelos";
            this.vuelosBindingSource.DataSource = this.tuViajeFinDeCursoDataSet;
            // 
            // tuViajeFinDeCursoDataSet
            // 
            this.tuViajeFinDeCursoDataSet.DataSetName = "TuViajeFinDeCursoDataSet";
            this.tuViajeFinDeCursoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vuelosTableAdapter
            // 
            this.vuelosTableAdapter.ClearBeforeFill = true;
            // 
            // mas800ToolStrip
            // 
            this.mas800ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mas800ToolStripButton});
            this.mas800ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mas800ToolStrip.Name = "mas800ToolStrip";
            this.mas800ToolStrip.Size = new System.Drawing.Size(111, 25);
            this.mas800ToolStrip.TabIndex = 2;
            this.mas800ToolStrip.Text = "mas800ToolStrip";
            // 
            // mas800ToolStripButton
            // 
            this.mas800ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mas800ToolStripButton.Name = "mas800ToolStripButton";
            this.mas800ToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.mas800ToolStripButton.Text = "mas800";
            this.mas800ToolStripButton.Click += new System.EventHandler(this.mas800ToolStripButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mas800ToolStrip);
            this.Controls.Add(this.mas500ToolStrip);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mas500ToolStrip.ResumeLayout(false);
            this.mas500ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vuelosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuViajeFinDeCursoDataSet)).EndInit();
            this.mas800ToolStrip.ResumeLayout(false);
            this.mas800ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TuViajeFinDeCursoDataSet tuViajeFinDeCursoDataSet;
        private System.Windows.Forms.BindingSource vuelosBindingSource;
        private TuViajeFinDeCursoDataSetTableAdapters.vuelosTableAdapter vuelosTableAdapter;
        private System.Windows.Forms.ToolStrip mas500ToolStrip;
        private System.Windows.Forms.ToolStripButton mas500ToolStripButton;
        private System.Windows.Forms.ToolStrip mas800ToolStrip;
        private System.Windows.Forms.ToolStripButton mas800ToolStripButton;
    }
}

