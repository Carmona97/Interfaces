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
/*      private NpgsqlConnection conn;
        private NpgsqlDataAdapter adapter;
        private DataSet dataSet;*/

        public Form1()
        {

        InitializeComponent();

            /*          NpgsqlConnection conn = new NpgsqlConnection("Server=Localhost;Port=5432;Database=TuViajeFinDeCurso;User Id=postgres;Password=123;");
                        conn.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from agencias";
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            ReportDataSource miReport = new ReportDataSource("VuelosTVFDC",dt);
                            this.reportViewer1.LocalReport.DataSources.Add(miReport);

                        }
                        cmd.Dispose();
                        conn.Close();*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string vuelo_id;
            string origen;
            string destino;
            string costo;
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=123;Database=TuViajeFinDeCurso");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT vuelo_id,origen,destino,costo FROM vuelos", conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Vuelos> listaDeVuelos = new List<Vuelos> ();

            while (reader.Read())
            {
                vuelo_id = reader[0].ToString();
                origen = reader[1].ToString();
                destino = reader[2].ToString();
                costo = reader[3].ToString();
            }
          
/*            // TODO: esta línea de código carga datos en la tabla 'tuViajeFinDeCursoDataSet.vuelos' Puede moverla o quitarla según sea necesario.
            this.vuelosTableAdapter.Fill(this.tuViajeFinDeCursoDataSet.vuelos);*/
            /*            // Establecer la conexión a la base de datos
                        conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=123;Database=TuViajeFinDeCurso");

                        // Establecer la consulta SQL
                        string query = "SELECT vuelo_id,origen,destino,costo FROM public.vuelos;";

                        // Crear el adaptador NpgsqlDataAdapter
                        adapter = new NpgsqlDataAdapter(query, conn);

                        // Crear e inicializar el DataSet
                        dataSet = new DataSet();

                        try
                        {
                            // Abrir la conexión
                            conn.Open();

                            // Llenar el DataSet con los datos de la consulta
                            adapter.Fill(dataSet, "VuelosTVFDC");

                            // Asignar el DataSet como origen de datos para el informe
                            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("VuelosTVFDC", dataSet.Tables["VuelosTVFDC"]));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cargar datos desde la base de datos: " + ex.Message);
                        }
                        finally
                        {
                            // Cerrar la conexión
                            conn.Close();
                        }*/

            this.reportViewer1.RefreshReport();
        }

        private void mas500ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.vuelosTableAdapter.mas500(this.tuViajeFinDeCursoDataSet.vuelos);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void mas800ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.vuelosTableAdapter.mas800(this.tuViajeFinDeCursoDataSet.vuelos);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
