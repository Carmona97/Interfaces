using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace camionero
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(rRoja.IsChecked == true)
            {
                
            }
            if(rAzul.IsChecked == true)
            {
                granada.IsEnabled = false;
            }
            
        }

        private void listRoja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void listAzul_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public int contadorParadasRoja()
        {
            int contador = 0;
            if (granada.IsSelected == true)
            {
                contador++;
            }
            if(jaen.IsSelected == true)
            {
                contador++;
            }
            if(ciudadreal.IsSelected == true)
            {
                contador++;
            }
            if(toledo.IsSelected == true)
            {
                contador++;
            }
            if(madrid.IsSelected == true)
            {
                contador++;
            }
            if(guadalajara.IsSelected == true)
            {
                contador++;
            }
            if(zaragoza.IsSelected == true)
            {
                contador++;
            }
            if(lerida.IsSelected == true)
            {
                contador++;
            }
            if(barcelona.IsSelected == true)
            {
                contador++;
            }
            return contador;
        }

        public int contadorParadasAzul()
        {
            int contador = 0;
            if (sevilla.IsSelected == true)
            {
                contador++;
            }
            if (merida.IsSelected == true)
            {
                contador++;
            }
            if (caceres.IsSelected == true)
            {
                contador++;
            }
            if (salamanca.IsSelected == true)
            {
                contador++;
            }
            if (zamora.IsSelected == true)
            {
                contador++;
            }
            if (orense.IsSelected == true)
            {
                contador++;
            }
            if (pontevedra.IsSelected == true)
            {
                contador++;
            }
            if (santiago.IsSelected == true)
            {
                contador++;
            }
            if (coruña.IsSelected == true)
            {
                contador++;
            }
            return contador;
        }

        public void calculoFactura(int paradas)
        {
            int mercancia = 0;
            int nocturnidad = 0;
            int total = 0;
            if(rAceite.IsChecked == true)
            {
                mercancia = 1000;
            }
            if(rFruta.IsChecked == true)
            {
                mercancia = 1200;
            }
            if(rPeligro.IsChecked == true)
            {
                mercancia = 2000;
            }
            if(chkNoche.IsChecked == true)
            {
                nocturnidad = 500;
            }

            int dineroPorParadas = paradas*100;
            
            if(chkRemolque.IsChecked == true)
            {
                total = mercancia + nocturnidad + dineroPorParadas;
                total = total + total * 50 / 100;

            }
            else
            {
                total = mercancia + nocturnidad+dineroPorParadas;
            }
            factura.Text = "Mercancia que transporta: "+mercancia.ToString()+"\nNocturnidad: "+nocturnidad+"\nCantidad paradas: "+paradas+"\nDinero por paradas: "+dineroPorParadas+"\nTotal: "+total;
        }

        private void btnFactura_Click(object sender, RoutedEventArgs e)
        {

            int paradas = 0;

            if (rRoja.IsChecked == true)
            {
                paradas = contadorParadasRoja();
            }
            if (rAzul.IsChecked == true)
            {
                paradas = contadorParadasAzul();

            }

            calculoFactura(paradas);

            if (rRoja.IsChecked == false && rAzul.IsChecked == false)
            {
                MessageBox.Show("No se ha seleccionado una ruta");
                factura.Text = "";
            }

            if(rAceite.IsChecked == false && rFruta.IsChecked == false && rPeligro.IsChecked == false)
            {
                MessageBox.Show("No se ha seleccionado una mercancia que transportar");
                factura.Text = "";
            }
            
            
        }

        private void limpiar_Click(object sender, RoutedEventArgs e)
        {
            factura.Text="";
            listAzul.UnselectAll();
            listRoja.UnselectAll();
            chkNoche.IsChecked = false;
            chkRemolque.IsChecked = false;
            
        }
    }
}
