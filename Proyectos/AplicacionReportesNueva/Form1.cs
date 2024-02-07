using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionReportesNueva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog seleccionarFichero = new OpenFileDialog();
            seleccionarFichero.InitialDirectory = "C:\\";
            seleccionarFichero.Filter = "csv files (*.csv)";
            seleccionarFichero.FilterIndex = 1;
            seleccionarFichero.Multiselect = false;

            if (seleccionarFichero.ShowDialog() == DialogResult.OK)
            {
                string nombreFichero = seleccionarFichero.FileName;
                lblRutaFichero.Text = nombreFichero;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
