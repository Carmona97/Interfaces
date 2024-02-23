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
using Npgsql;

namespace CarmonaJuanManuelExamenT5
{
    public partial class Form2 : Form
    {
        string zonaHoraria;
        string ciudadSeleccionada;
        string condicion;
        public Form2(string zonaHoraria, string ciudadSeleccionada, string condicion)
        {
            InitializeComponent();
            this.zonaHoraria = zonaHoraria;
            this.ciudadSeleccionada = ciudadSeleccionada;
            this.condicion = condicion;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*            // TODO: esta línea de código carga datos en la tabla 'eEUUDataSet.Ciudades' Puede moverla o quitarla según sea necesario.
                        this.ciudadesTableAdapter.Fill(this.eEUUDataSet.Ciudades);*/

            string querySinCondiciones = "SELECT * FROM \"Ciudades\" ";
            string query = "";
            string conexionBBDD = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=EEUU";

            if(ciudadSeleccionada != "")
            {
                query = querySinCondiciones + "WHERE name = " + ciudadSeleccionada;
            }
            else
            {
                query = querySinCondiciones;
            }

            NpgsqlConnection conn = new NpgsqlConnection(conexionBBDD);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Eeuu> ciudadesEEUU = new List<Eeuu>();

            while (reader.Read())
            {
                Eeuu nuevaCiudad = new Eeuu();
                nuevaCiudad.name = reader[0].ToString();
                nuevaCiudad.latitude = reader[1].ToString();
                nuevaCiudad.longitude = reader[2].ToString();
                nuevaCiudad.population = reader[3].ToString();
                nuevaCiudad.timezone = reader[4].ToString();
                
                ciudadesEEUU.Add(nuevaCiudad);
                
            }

            ReportDataSource ds = new ReportDataSource("DataSet1", ciudadesEEUU);
            reportViewer1.LocalReport.DataSources.Add(ds);

            conn.Close();

            ReportParameterCollection parametro = new ReportParameterCollection();

            parametro.Add(new ReportParameter("ReportParameter1", zonaHoraria));

            reportViewer1.LocalReport.SetParameters(parametro);            
            
            ReportParameterCollection parametro2 = new ReportParameterCollection();

            parametro2.Add(new ReportParameter("ReportParameter2", ciudadesEEUU.Count.ToString()));

            reportViewer1.LocalReport.SetParameters(parametro2);
            this.reportViewer1.RefreshReport();
        }
    }
}
