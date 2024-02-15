using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportUsingAPI
{
    public partial class Form1 : Form
    {

        List<TiendaRopa> objetosTiendaRopa = new List<TiendaRopa>();

        public Form1()
        {
            InitializeComponent();
            var client = new RestClient("https://fakestoreapi.com");
            var request = new RestRequest("/products", Method.Get);
            RestResponse response = client.Execute(request);
            var json = response.Content;
            var objetos = JsonConvert.DeserializeObject<List<TiendaRopa>>(json);
            foreach (var objeto in objetos)
            {
                TiendaRopa nuevoObjeto = new TiendaRopa();
                nuevoObjeto.id = objeto.id;
                nuevoObjeto.title = objeto.title;
                nuevoObjeto.description = objeto.description;
                nuevoObjeto.price = objeto.price;
                nuevoObjeto.category = objeto.category;

                objetosTiendaRopa.Add(nuevoObjeto);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = typeof(TiendaRopa);

            for(int i = 0;i < objetosTiendaRopa.Count;i++)
            {
                bs.Add(objetosTiendaRopa[i]);
            }

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", bs));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
