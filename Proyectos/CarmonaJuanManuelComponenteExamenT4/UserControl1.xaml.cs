using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarmonaJuanManuelComponenteExamenT4
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl
    {

        public UserControl1()
        {
            InitializeComponent();
            
        }
        private int numeroMaximo;
        [Description("Cantidad máxima de caracteres del texto"), Category("Mi categoria"), DisplayName("Introduzca la longitud maxima")]
        public int maxCaracteres { 
            get => texto.MaxLength; 
            set => texto.MaxLength = value; 
        }

        [Description("Cantidad máxima de elementos que puede haber en la lista"), Category("Mi categoria"), DisplayName("Introduzca la cantidad de elementos maximos")]
        public int maxElementos {
            get => numeroMaximo; 
            set { miSlider.Maximum = value; numeroMaximo = value; }
        }
        [Description("Color de fondo en el slider"),Category("Mi categoria"), DisplayName("Color slider")]
        public Brush sliderFondo { get=>miSlider.Background; set=>miSlider.Background=value; }
        [Description("Obtener la lista"), Category("Mi categoria"), DisplayName("Elementos lista")]
        public ItemCollection miColeccion { get=>lista.Items;}
        private void texto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void Texto_keydown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (lista.Items.Count < numeroMaximo)
                {
                    lista.Items.Add(texto.Text);
                    texto.Text = "";
                    miSlider.Value = (double)lista.Items.Count;

                }
                else
                {
                    texto.Background = new SolidColorBrush(Colors.Red);
                    texto.Text = "";
                }

            }
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void miSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void lista_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Delete) {
                lista.Items.Remove(lista.SelectedItem);
                miSlider.Value = lista.Items.Count;
            }
        }
    }
}
