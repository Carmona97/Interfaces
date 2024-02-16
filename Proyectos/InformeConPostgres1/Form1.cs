using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InformeConPostgres1.TuViajeFinDeCursoDataSetTableAdapters;
using Microsoft.Reporting.WinForms;
using Npgsql;

namespace InformeConPostgres1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

        InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string vuelo_id;
            string origen;
            string destino;
            string costo;
            string query = "SELECT vuelo_id,origen,destino,costo FROM vuelos";
            string query2 = "SELECT * FROM agencias";
            string conexionBBDD = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=TuViajeFinDeCurso";
            
            NpgsqlConnection conn = new NpgsqlConnection(conexionBBDD);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            //NpgsqlCommand cmd2 = new NpgsqlCommand(query2, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            //NpgsqlDataReader reader2 = cmd2.ExecuteReader();

            List<Vuelos> listaDeVuelos = new List<Vuelos>();
            List<Agencia> listaDeAgencia = new List<Agencia>();

            while (reader.Read())
            {
                vuelo_id = reader[0].ToString();
                origen = reader[1].ToString();
                destino = reader[2].ToString();
                costo = reader[3].ToString();
                Vuelos nuevoVuelo = new Vuelos(vuelo_id, origen, destino, costo);
                listaDeVuelos.Add(nuevoVuelo);
            }

            //while (reader2.Read())
            //{
            //    Agencia agencia = new Agencia {
            //        agencia_id =  (int)reader2[0],
            //        nombre_agencia= reader2[1].ToString(),
            //        direccion_agencia= reader2[2].ToString(),
            //        telefono_agencia= reader2[3].ToString()
            //    };
            //    listaDeAgencia.Add(agencia);
            //}

            //BindingSource bs = new BindingSource();
            //bs.DataSource = typeof(Vuelos);

            //for (int i = 0; i < listaDeVuelos.Count; i++)
            //{
            //    bs.Add(listaDeVuelos[i]);
            //}

            ReportDataSource ds = new ReportDataSource("Vuelos", listaDeVuelos);
            //ReportDataSource ds2 = new ReportDataSource("DataSet1", listaDeAgencia);
            reportViewer1.LocalReport.DataSources.Add(ds);
            //reportViewer1.LocalReport.DataSources.Add(ds2);

            ReportParameterCollection parametro = new ReportParameterCollection();

            parametro.Add(new ReportParameter("ReportParameter1", "Hola mundo"));

            reportViewer1.LocalReport.SetParameters(parametro);

            this.reportViewer1.RefreshReport();
        }

    }
}
