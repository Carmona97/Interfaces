using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace componenteRepaso
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        int maximoElementosVariable;
        String mayorLongitud = "";
        [Description("Cantidad de elementos maximos de la lista"),Category("Componente"),DisplayName("Cantidad maxima elementos")]
        public int maximoElementosLista { get => maximoElementosVariable; set => listaMaxItems(value); }
        [Description("Cantidad maxima de caracteres"), Category("Componente"),DisplayName("Cantidad maxima de caracteres")]

        public int maximoCaracteresTexto { get => miTexto.MaxLength; set => miTexto.MaxLength = value; }
        [Description("Color de fondo del slider"), Category("Componente"),DisplayName("Color fondo")]
        public Brush fondoSlider { get => miSlider.Background; set => miSlider.Background = value; }
        public string mayorLongitudCadena { get => mayorLongitud;}
        public UserControl1()
        {
            InitializeComponent();
        }

        public int listaMaxItems(int valor)
        {
            maximoElementosVariable = valor;
            miSlider.Maximum = maximoElementosVariable;
            return maximoElementosVariable;
        }

        private void e(object sender, KeyEventArgs e)
        {
            if(miLista.Items.Count < maximoElementosLista)
            {
                if (e.Key == Key.Enter && miTexto.Text != "")
                {
                    miLista.Items.Add(miTexto.Text);
                    miTexto.Text = "";
                    miSlider.Value = miLista.Items.Count;
                    elementoListaMayorLongitud();
                }
            }

            if(miLista.Items.Count == maximoElementosLista)
            {
                miSlider.Value = maximoElementosLista;
                miSlider.Background = Brushes.Red; 
            }

            

        }

        public String elementoListaMayorLongitud()
        {
            for(int i = 0; i < miLista.Items.Count; i++)
            {
                if(miLista.Items[i].ToString().Length > mayorLongitud.Length)
                {
                    mayorLongitud = miLista.Items[i].ToString();
                }
            }

            return mayorLongitud;
        }

        private void supr(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                miLista.Items.Remove(miLista.SelectedItem);
                miSlider.Value = miLista.Items.Count;
            }
        }
    }
}
