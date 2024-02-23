using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarmonaJuanManuelExamenT5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zonaHoraria;
            if (ny.Checked == true)
            {
                zonaHoraria = ny.Text;
            }else if(lA.Checked == true)
            {
                zonaHoraria = lA.Text;
            }else if(chicago.Checked == true)
            {
                zonaHoraria= chicago.Text;
            }
            else
            {
                zonaHoraria = "";
            }

            string condicion="";

            if(granCiudad.Checked == true)
            {
                condicion = "population > 1000000";
            }

            string ciudadSeleccionada="";
            
            if(nombreCiudad.Text != "")
            {
                ciudadSeleccionada = nombreCiudad.Text;
            }

            Form2 nuevaForm = new Form2(zonaHoraria, ciudadSeleccionada, condicion);
            nuevaForm.Show();
        }

    }
}
