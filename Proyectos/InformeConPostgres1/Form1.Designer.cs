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
            this.vuelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tuViajeFinDeCursoDataSet = new InformeConPostgres1.TuViajeFinDeCursoDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vuelosTableAdapter = new InformeConPostgres1.TuViajeFinDeCursoDataSetTableAdapters.vuelosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vuelosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuViajeFinDeCursoDataSet)).BeginInit();
            this.SuspendLayout();
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
            // vuelosTableAdapter
            // 
            this.vuelosTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vuelosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuViajeFinDeCursoDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TuViajeFinDeCursoDataSet tuViajeFinDeCursoDataSet;
        private System.Windows.Forms.BindingSource vuelosBindingSource;
        private TuViajeFinDeCursoDataSetTableAdapters.vuelosTableAdapter vuelosTableAdapter;
    }
}

