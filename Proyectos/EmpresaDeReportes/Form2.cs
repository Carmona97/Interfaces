using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaDeReportes
{
    public partial class Form2 : Form
    {

        private List<DatosDelCSV> objetosCSV;

        public Form2(List<DatosDelCSV> objetosCSV)
        {
            InitializeComponent();
            this.objetosCSV = objetosCSV;
        }

        private void Form2_Load(object sender, EventArgs e)
        {           
            BindingSource bs = new BindingSource();
            bs.DataSource = typeof(DatosDelCSV);

            for (int i = 1; i < objetosCSV.Count; i++)
            {
                bs.Add(objetosCSV[i]);
            }

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", bs));
            this.reportViewer1.RefreshReport();
        }

    }
}
