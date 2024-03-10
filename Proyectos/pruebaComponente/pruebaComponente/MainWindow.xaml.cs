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

namespace pruebaComponente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool activado = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void miSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            miTexto.Text = "Velocidad: "+miSlider.Value.ToString();
        }

        private void miBtn_Click(object sender, RoutedEventArgs e)
        {
            if (activado)
            {
                miReloj.segundo += (int)miSlider.Value;
                if (miReloj.segundo > 60)
                {
                    miReloj.segundo = miReloj.segundo - 60;
                    miReloj.minuto = miReloj.minuto + 1;
                    if (miReloj.minuto > 60)
                    {
                        miReloj.minuto -= 60;
                        miReloj.hora = miReloj.hora + 1;
                        if (miReloj.hora > 12)
                        {
                            miReloj.hora = 1;
                        }
                    }
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void desactivarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (activado)
            {
                activado = false;
                desactivarBtn.Content = "Activar";
            }
            else
            {
                activado = true;
                desactivarBtn.Content = "Desactivar";
            }
        }
    }
}
