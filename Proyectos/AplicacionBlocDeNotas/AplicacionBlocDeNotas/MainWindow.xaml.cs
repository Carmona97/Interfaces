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

namespace AplicacionBlocDeNotas
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

        private void btnVisualizar_Click(object sender, RoutedEventArgs e)
        {
            blocNotas.verTextoGuardado = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            blocNotas.verTextoGuardado = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string textoAGuardar = blocNotas.textoIzquierda;
            blocNotas.textoDerecha += textoAGuardar;
        }

        private void fondoAzul_Click(object sender, RoutedEventArgs e)
        {
            blocNotas.cambiarFondo = new SolidColorBrush(Colors.Blue);
        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            blocNotas.textoIzquierda = "";
            blocNotas.textoDerecha = "";
        }

        private void fondoVerde_Click(object sender, RoutedEventArgs e)
        {
            blocNotas.cambiarFondo = new SolidColorBrush(Colors.Green);
        }

        private void fondoRojo_Click(object sender, RoutedEventArgs e)
        {
            blocNotas.cambiarFondo = new SolidColorBrush(Colors.Red);
        }
    }
}
    