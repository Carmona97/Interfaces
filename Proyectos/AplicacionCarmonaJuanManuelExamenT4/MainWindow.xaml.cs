using System;
using System.Collections;
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

namespace AplicacionCarmonaJuanManuelExamenT4
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            String palabraMasLarga = "";
            foreach(String palabra in miControl.miColeccion){
                if (palabra.Length > palabraMasLarga.Length)
                {
                    palabraMasLarga = palabra;
                }
            }
            verElemento.Text = palabraMasLarga;
        }
    }
}
