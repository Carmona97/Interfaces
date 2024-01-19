using System;
using System.Collections.Generic;
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

namespace AplicacionBarraProgreso
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void anadirProgreso_Click(object sender, RoutedEventArgs e)
        {
            int sumarProgreso = int.Parse(miBarra.BarraProgreso);
            sumarProgreso++;
            string nuevoValor = sumarProgreso.ToString();
            miBarra.establecerValor(nuevoValor);
        }

        private void reiniciarProgreso_Click(object sender, RoutedEventArgs e)
        {
            int sumarProgreso = int.Parse(miBarra.BarraProgreso);
            sumarProgreso = 0;
            string nuevoValor = sumarProgreso.ToString();
            miBarra.establecerValor(nuevoValor);
        }
    }
}
