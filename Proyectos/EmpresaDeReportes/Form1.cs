﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaDeReportes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog seleccionarFichero = new OpenFileDialog();
            seleccionarFichero.InitialDirectory = "C:\\";
            seleccionarFichero.Filter = "csv files (*.csv) | *.csv";
            seleccionarFichero.FilterIndex = 1;
            seleccionarFichero.Multiselect = false;

            if (seleccionarFichero.ShowDialog() == DialogResult.OK)
            {
                string nombreFichero = seleccionarFichero.FileName;
                lblRutaFichero.Text = nombreFichero;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            string rutaCSV = lblRutaFichero.Text;
            StreamReader lecturaFichero = new StreamReader(rutaCSV);

            
            List<DatosDelCSV> objetosCSV = new List<DatosDelCSV>();

            string leerLinea = lecturaFichero.ReadLine();

            while (leerLinea != null)
            {
                leerLinea = lecturaFichero.ReadLine();
                if( leerLinea != null )
                {
                    DatosDelCSV objetoNuevo = new DatosDelCSV();
                    string[] elementosLinea = leerLinea.Split(',');
                    objetoNuevo.levelType = elementosLinea[0];
                    objetoNuevo.code = elementosLinea[1];
                    objetoNuevo.catalogType = elementosLinea[2];
                    objetoNuevo.name = elementosLinea[3];
                    objetoNuevo.description = elementosLinea[4];
                    objetoNuevo.sourceLink = elementosLinea[5];

                    objetosCSV.Add(objetoNuevo);
                }

                                
            }



            Form2 nuevaVentana = new Form2(objetosCSV);
            nuevaVentana.Show();


            
            
        }

        
    }
}
